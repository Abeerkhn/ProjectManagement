namespace Softwash.Application.Features.Auth.Commands.CreatePassword;

public class CreatePasswordCommandValidator : AbstractValidator<CreatePasswordCommandDTO>
{
    public CreatePasswordCommandValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$").WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.");

        RuleFor(x => x.EmailOrPhoneNumber)
       .NotEmpty().WithMessage("Email Or Phonenumber is required")
       .Matches(@"^(?:\d{10,15}|[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$")
       .WithMessage("Provide a valid email address or phone number (10-15 digits).");
    }
}
