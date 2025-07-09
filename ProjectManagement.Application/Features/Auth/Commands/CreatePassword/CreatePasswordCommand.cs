namespace Softwash.Application.Features.Auth.Commands.CreatePassword;
public class CreatePasswordCommand : IRequest<OutputDTO<object>>
{
    public CreatePasswordCommandDTO dto { get; set; }
}

public class CreatePasswordCommandHandler : IRequestHandler<CreatePasswordCommand, OutputDTO<object>>
{
    readonly IAuthService _authService;

    public CreatePasswordCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    async Task<OutputDTO<object>> IRequestHandler<CreatePasswordCommand, OutputDTO<object>>.Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
    {
        return await _authService.CreatePassword(request.dto);
    }
}
