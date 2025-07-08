namespace Softwash.Infrastructure.Services.AuthModule.Auth;
public class AuthService(IUnitOfWork unitOfWork, IMapper mapper) : IAuthService
{
    readonly IUnitOfWork _unitOfWork = unitOfWork;
    readonly IMapper _mapper = mapper;
    const string entity = "User";
    const string imageEntity = $"{entity} Image";
    const string phone = "Phone Number";
    const string email = "Email";
    const string password = "Password";

    public async Task<OutputDTO<object>> Login(string emailOrPhoneNumber, string password)
    {
     


        var user = await _unitOfWork.UserRepo.AsQueryable().AsNoTracking().AsSplitQuery().Include(_ => _.Login)
                    .Where(_ => _.Email == emailOrPhoneNumber).FirstOrDefaultAsync();

        if (user is null)
            return Output.Handler<object>((int)ResponseType.NOT_EXIST, new LoginResponseDTO(new User(), new Login(), string.Empty), entity);

        if (!user.Login.IsProfileCompleted)
            return Output.Handler<object>((int)ResponseType.INCOMPLETE_PROFILE, new LoginResponseDTO(user, user.Login, string.Empty), entity);

        if (!user.Login.IsProfileCompleted)
        {
            return Output.Handler<object>((int)ResponseType.CUSTOM_RESPONSE, new LoginResponseDTO(user, user.Login, string.Empty), "Setup Your Password.");
        }

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Login.Password);
        if (!isPasswordValid)
            return Output.Handler<object>((int)ResponseType.INVALID_CREDENTIALS, new LoginResponseDTO(user, user.Login, string.Empty), entity);

        bool isVerified = user.Login.IsVerified == true ? true : false;
        if (!isVerified)
            return Output.Handler<object>((int)ResponseType.NOT_VERIFIED, new LoginResponseDTO(user, user.Login, string.Empty), entity);

        var response = AuthResponse(user, user.Login);

        return Output.Handler<object>((int)ResponseType.SUCCESSFULLY_LOGIN, response, entity);
 
    }
    public async Task<OutputDTO<object>> SignUp(SignUpCommandDTO dto)
    {
        dto.Password = "12345678";

        bool emailCheck = await CheckEmail(email);
        if (emailCheck)
            return Output.Handler<object>((int)ResponseType.ALREADY_EXIST, false, entity);

        string path = ImageHelper.SaveBase64ToImage(dto.Image, imageEntity);

        var userObj = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.EmailOrPhoneNumber,
            CreatedDate = DateTime.UtcNow,
            Image = path
        };

        var loginObj = new Login
        {
            IsVerified = false,
            IsPasswordSetted = true,
            IsProfileCompleted = true,
            OTP = "1111",
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            User = userObj,
        };

        await _unitOfWork.UserRepo.AddAsync(userObj);
        await _unitOfWork.LoginRepo.AddAsync(loginObj);
        await _unitOfWork.Save();

        bool result = true;
        string contactInfo = dto.EmailOrPhoneNumber.Contains("@") ? email : phone;

        if (!result)
            return Output.Handler<object>((int)ResponseType.CUSTOM_ERROR, new LoginResponseDTO(new User(), new Login(), string.Empty), $"Something Wrong in Provided {contactInfo} : {dto.EmailOrPhoneNumber} ");

        var response = AuthResponse(userObj, loginObj);

        return Output.Handler<object>((int)ResponseType.SEND_OTP, response, entity);

    }

    public async Task<OutputDTO<object>> CreatePassword(CreatePasswordCommandDTO dto)
    {
    
        var user = await _unitOfWork.UserRepo.AsQueryable().AsNoTracking().AsSingleQuery().Include(x => x.Login).Where(x => x.Email == dto.EmailOrPhoneNumber).FirstOrDefaultAsync();
        if (user == null)
            return Output.Handler<object>((int)ResponseType.NOT_EXIST, false, entity);

        //user.Login.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        user.Login.Password = BCrypt.Net.BCrypt.HashPassword("12345678");
        user.Login.IsPasswordSetted = true;

        await _unitOfWork.LoginRepo.UpdateAsync(user.Login);
        await _unitOfWork.Save();

        return Output.Handler<object>((int)ResponseType.UPDATE, true, password);
    }
    protected LoginResponseDTO AuthResponse(User user, Login login)
    {
        
        var sessionDTO = new SessionDTO()
        {
            UserId = user.Id,
            EmailOrPhoneNumber = user.Email,
        };
        string token = JWTs.GenerateJwtToken(sessionDTO) ?? string.Empty;
        return new LoginResponseDTO(user, login, token);
      
    }

    private async Task<bool> CheckEmail(string emailOrPhoneNumber, long userId = 0)
    {

        var filter = PredicateBuilder.True<Softwash.Domain.Entities.User>();

        if (userId > 0)
            filter = filter.And(x => x.Email.Equals(emailOrPhoneNumber) && x.Id != userId && !x.IsDeleted);
        else
            filter = filter.And(x => x.Email.Equals(emailOrPhoneNumber) && !x.IsDeleted);

        return await _unitOfWork.UserRepo.AsQueryable().AnyAsync(filter);
       
    }

}



