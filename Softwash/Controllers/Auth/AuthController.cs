using Softwash.Application.Features.Auth.Commands.CreatePassword;
using Softwash.Application.Features.Auth.Commands.Logins;
using Softwash.Application.Features.Auth.Commands.Signup;

namespace Softwash.Controllers.Auth;

[Route("api/auth")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OutputDTO<LoginResponseDTO>))]
    public async Task<IActionResult> Login(string emailOrPhoneNumber, string password) => Ok(await _mediator.Send(new LoginCommand() { EmailOrPhoneNumber = emailOrPhoneNumber, Password = password }));

    [HttpPost("signup")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OutputDTO<LoginResponseDTO>))]
    public async Task<IActionResult> SignUp(SignUpCommandDTO dto) => Ok(await _mediator.Send(new SignupCommand() { dto = dto }));

    
    [HttpPost("createPassword")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OutputDTO<LoginResponseDTO>))]
    public async Task<IActionResult> CreatePassword(CreatePasswordCommandDTO dto) => Ok(await _mediator.Send(new CreatePasswordCommand() { dto = dto }));

    //[HttpPost("verifyOTP")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OutputDTO<LoginResponseDTO>))]
    //public async Task<IActionResult> VerifyOTP(VerifyOtpDTO dto) => Ok(await _mediator.Send(new VerifyOTPCommand() { dto = dto }));

    //[HttpGet("resetPassword")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OutputDTO<LoginResponseDTO>))]
    //public async Task<IActionResult> ResetPassword(string emailOrPhoneNumber) => Ok(await _mediator.Send(new ResetPasswordCommand() { EmailOrPhoneNumber = emailOrPhoneNumber }));

}

