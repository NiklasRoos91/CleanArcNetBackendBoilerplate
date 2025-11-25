using CleanArcNetBackendBoilerplate.Application.Commons.OperationResult;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Dtos;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Mappers;
using CleanArcNetBackendBoilerplate.Domain.Entities;
using CleanArcNetBackendBoilerplate.Domain.Interfaces;
using MediatR;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Queries.ListUsers
{
    public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, OperationResult<IEnumerable<UserDto>>>
    {
        private readonly IGenericRepository<User> _userRepository;

        public ListUsersQueryHandler(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<IEnumerable<UserDto>>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.ListAsync(cancellationToken);
            var usersDtos = users.Select(UserDtoMapper.Map).ToList();

            return OperationResult<IEnumerable<UserDto>>.Success(usersDtos);
        }
    }
}
