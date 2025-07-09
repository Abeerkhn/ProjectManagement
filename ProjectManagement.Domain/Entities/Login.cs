namespace Softwash.Domain.Entities
{
    public class Login : BaseDeleteableEntity
    {
        public long? UserId { get; set; }
        public string? Password { get; set; }
        public string? OTP { get; set; }
        public DateTime? OTPExpiry { get; set; }
        public bool IsVerified { get; set; }
        public bool IsProfileCompleted { get; set; }
        public bool IsPasswordSetted { get; set; }
        public User? User { get; set; }
    }
}