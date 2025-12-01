using CleanArcNetBackendBoilerplate.Application.Feature.AuthFeature.Commands.Login;
using CleanArcNetBackendBoilerplate.Application.Feature.AuthFeature.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArcNetBackendBoilerplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var command = new LoginCommand(loginRequestDto);

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new { message = result.ErrorMessage });

            return Ok(result.Data);
        }

    }
}
