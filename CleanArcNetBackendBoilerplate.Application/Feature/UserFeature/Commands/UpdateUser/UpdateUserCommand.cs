using CleanArcNetBackendBoilerplate.Application.Commons.OperationResult;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Dtos;
using MediatR;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Commands.UpdateUser
{

    public class UpdateUserCommand : IRequest<OperationResult<UserDto>>
    {
        public Guid Id { get; }
        public UpdateUserDto UpdateUserDto { get; }

        public UpdateUserCommand(Guid id, UpdateUserDto updateUserDto)
        {
            Id = id;
            UpdateUserDto = updateUserDto;
        }
    }
}
