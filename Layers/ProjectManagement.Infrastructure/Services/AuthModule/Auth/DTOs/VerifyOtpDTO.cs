namespace Softwash.Infrastructure.Services.AuthModule.Auth.DTOs;

public class VerifyOtpDTO
{
    public string? EmailOrPhoneNumber { get; set; }
    public string? OTP { get; set; }
    public bool IsSignUp { get; set; }
}
