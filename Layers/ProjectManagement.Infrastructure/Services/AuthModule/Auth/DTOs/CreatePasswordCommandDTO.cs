namespace Softwash.Infrastructure.Services.AuthModule.Auth.DTOs;
public class CreatePasswordCommandDTO
{
    public string Password { get; set; }
    public string EmailOrPhoneNumber { get; set; }
}
