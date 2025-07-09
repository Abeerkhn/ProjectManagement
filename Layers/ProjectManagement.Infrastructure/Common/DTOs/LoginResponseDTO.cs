namespace Softwash.Infrastructure.Common.DTOs;

public class LoginResponseDTO
{
    public LoginResponseDTO(User user, Login login, string token)
    {
        UserId = user.Id == null ? 0 : user.Id;
        EmailOrPhoneNumber = user.Email ?? string.Empty;
        IsVerified = login.IsVerified;
        IsPasswordSetted = login.IsPasswordSetted;
        IsProfileCompleted = login.IsProfileCompleted;
        Image = string.IsNullOrEmpty(user.Image) ? string.Empty : user.Image;
        Token = token ?? string.Empty;
    }

        public long? UserId { get; set; }
        public string? EmailOrPhoneNumber { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsProfileCompleted { get; set; }
        public bool? IsPasswordSetted { get; set; }
        public string? Token { get; set; }
        public string? Image { get; set; }
    
}
