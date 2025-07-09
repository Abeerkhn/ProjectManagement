namespace Softwash.Application.Features.Auth.Commands.Logins;

public class LoginCommand : IRequest<OutputDTO<object>>
{
    public string EmailOrPhoneNumber { get; set; }
    public string Password { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, OutputDTO<object>>
{
    readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    async Task<OutputDTO<object>> IRequestHandler<LoginCommand, OutputDTO<object>>.Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _authService.Login(request.EmailOrPhoneNumber, request.Password);
    }
}
