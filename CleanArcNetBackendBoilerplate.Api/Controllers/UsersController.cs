using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Commands.CreateUser;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Commands.DeleteUser;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Commands.UpdateUser;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Dtos;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Queries.GetUserById;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Queries.ListUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArcNetBackendBoilerplate.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new ListUsersQuery());
            return result.IsSuccess ? Ok(result.Data) : NotFound(result.ErrorMessage);
        }

        // GET api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return result.IsSuccess ? Ok(result.Data) : NotFound(result.ErrorMessage);
        }

        // POST api/users
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            var command = new CreateUserCommand(dto);
            var result = await _mediator.Send(command);
            return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Data!.Id }, result.Data)
                                    : BadRequest(result.ErrorMessage);
        }

        // PATCH api/users/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
        {
            var command = new UpdateUserCommand(id, dto);
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result.Data) : NotFound(result.ErrorMessage);
        }

        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);
            return result.IsSuccess ? NoContent() : NotFound(result.ErrorMessage);
        }
    }
}
