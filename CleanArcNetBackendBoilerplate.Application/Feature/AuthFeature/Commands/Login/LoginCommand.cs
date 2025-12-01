using CleanArcNetBackendBoilerplate.Application.Commons.OperationResult;
using CleanArcNetBackendBoilerplate.Application.Feature.AuthFeature.Dtos;
using MediatR;

namespace CleanArcNetBackendBoilerplate.Application.Feature.AuthFeature.Commands.Login
{
    public class LoginCommand : IRequest<OperationResult<LoginResponseDto>>
    {
        public LoginRequestDto LoginRequestDto { get; set; }
        public LoginCommand(LoginRequestDto loginRequestDto)
        {
            LoginRequestDto = loginRequestDto;
        }
    }
}