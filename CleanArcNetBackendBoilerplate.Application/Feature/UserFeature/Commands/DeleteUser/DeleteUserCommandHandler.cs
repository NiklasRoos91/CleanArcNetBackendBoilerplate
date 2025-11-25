using CleanArcNetBackendBoilerplate.Application.Commons.OperationResult;
using CleanArcNetBackendBoilerplate.Domain.Entities;
using CleanArcNetBackendBoilerplate.Domain.Interfaces;
using MediatR;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<User> _userRepository;

        public DeleteUserCommandHandler(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
                return OperationResult<bool>.Failure($"User with ID {request.Id} not found.");

            await _userRepository.DeleteAsync(user, cancellationToken);

            return OperationResult<bool>.Success(true);
        }
    }
}
