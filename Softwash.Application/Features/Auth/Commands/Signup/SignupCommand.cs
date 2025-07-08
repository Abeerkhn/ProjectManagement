namespace Softwash.Application.Features.Auth.Commands.Signup;

public class SignupCommand : IRequest<OutputDTO<object>>
{
    public SignUpCommandDTO dto { get; set; }

}

public class SignupCommandHandler : IRequestHandler<SignupCommand, OutputDTO<object>>
{
    readonly IAuthService _authService;

    public SignupCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    async Task<OutputDTO<object>> IRequestHandler<SignupCommand, OutputDTO<object>>.Handle(SignupCommand request, CancellationToken cancellationToken)
    {
        return await _authService.SignUp(request.dto);
    }
}
