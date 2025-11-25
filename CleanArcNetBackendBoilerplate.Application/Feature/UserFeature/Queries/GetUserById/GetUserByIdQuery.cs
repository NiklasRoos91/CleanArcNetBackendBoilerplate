using CleanArcNetBackendBoilerplate.Application.Commons.OperationResult;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Dtos;
using MediatR;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<OperationResult<UserDto>>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
