namespace Softwash.Infrastructure.Services.AuthModule.Auth.DTOs;

public class SignUpCommandDTO
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string EmailOrPhoneNumber { get; set; }
    public string Password { get; set; }
    public string? Image { get; set; }
}

public class UserProfileDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? EmailOrPhoneNumber { get; set; }
    public string? Image { get; set; }
}