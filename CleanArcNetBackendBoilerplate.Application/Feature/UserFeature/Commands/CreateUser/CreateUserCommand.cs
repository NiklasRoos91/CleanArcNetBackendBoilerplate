using CleanArcNetBackendBoilerplate.Application.Commons.OperationResult;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Dtos;
using MediatR;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<OperationResult<UserDto>>
    {
        public CreateUserDto CreateUserDto { get; set; }
        public CreateUserCommand(CreateUserDto createUserDto)
        {
            CreateUserDto = createUserDto;
        }
    }
}
