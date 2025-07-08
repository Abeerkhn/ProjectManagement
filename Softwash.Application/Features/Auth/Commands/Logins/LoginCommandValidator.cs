namespace Softwash.Application.Features.Auth.Commands.Logins;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.")
         .NotEmpty().WithMessage("Password is required.");


        RuleFor(x => x.EmailOrPhoneNumber).NotEmpty().WithMessage("Email Or Phonenumber is required")
           .NotEmpty().WithMessage("Email Or Phonenumber is required");
    }
}
