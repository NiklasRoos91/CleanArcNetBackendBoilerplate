using CleanArcNetBackendBoilerplate.Application.Commons.OperationResult;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Dtos;
using MediatR;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Queries.ListUsers
{
    public class ListUsersQuery : IRequest<OperationResult<IEnumerable<UserDto>>>
    {
    }
}
