namespace Softwash.Infrastructure.Services.AuthModule.Auth
{
    public interface IAuthService
    {
        Task<OutputDTO<object>> Login(string emailOrPhoneNumber, string password);
        Task<OutputDTO<object>> SignUp(SignUpCommandDTO request);
       // Task<OutputDTO<object>> ResetPassword(string emailOrPhoneNumber);
        //Task<OutputDTO<object>> OAuth(string email);
        Task<OutputDTO<object>> CreatePassword(CreatePasswordCommandDTO request);
     //   Task<OutputDTO<object>> VerifyOTP(VerifyOtpDTO request);
    }
}
