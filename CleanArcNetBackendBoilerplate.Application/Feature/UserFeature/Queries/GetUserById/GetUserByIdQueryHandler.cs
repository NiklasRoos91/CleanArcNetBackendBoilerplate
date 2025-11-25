using CleanArcNetBackendBoilerplate.Application.Commons.OperationResult;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Dtos;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Mappers;
using CleanArcNetBackendBoilerplate.Domain.Entities;
using CleanArcNetBackendBoilerplate.Domain.Interfaces;
using MediatR;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, OperationResult<UserDto>>
    {
        private readonly IGenericRepository<User> _userRepository;

        public GetUserByIdQueryHandler(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
                return OperationResult<UserDto>.Failure($"User with ID {request.Id} not found.");

            var userDto = UserDtoMapper.Map(user);

            return OperationResult<UserDto>.Success(userDto);
        }
    }
}
