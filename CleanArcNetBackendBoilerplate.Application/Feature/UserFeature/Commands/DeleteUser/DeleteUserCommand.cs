using CleanArcNetBackendBoilerplate.Application.Commons.OperationResult;
using MediatR;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<OperationResult<bool>>
    {
        public Guid Id { get; }

        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
