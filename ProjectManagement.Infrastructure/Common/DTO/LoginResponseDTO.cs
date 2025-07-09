namespace Softwash.Infrastructure.Common.DTOs;

public class LoginResponseDTO
{
    public LoginResponseDTO(User user, Login login, string token)
    {
        UserId = user.Id == null ? 0 : user.Id;
        EmailOrPhoneNumber = user.Email ?? string.Empty;
        Image = string.IsNullOrEmpty(user.Image) ? string.Empty : user.Image;
        Token = token ?? string.Empty;
    }

        public long? UserId { get; set; }
        public string? EmailOrPhoneNumber { get; set; }
        public string? Token { get; set; }
        public string? Image { get; set; }
    
}
