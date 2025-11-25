using CleanArcNetBackendBoilerplate.Application.Commons.OperationResult;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Dtos;
using CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Mappers;
using CleanArcNetBackendBoilerplate.Domain.Entities;
using CleanArcNetBackendBoilerplate.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArcNetBackendBoilerplate.Application.Feature.UserFeature.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OperationResult<UserDto>>
    {
        private readonly IGenericRepository<User> _userRepository;

        public CreateUserCommandHandler(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.CreateUserDto.FirstName,
                LastName = request.CreateUserDto.LastName,
                Email = request.CreateUserDto.Email
            };

            var hasher = new PasswordHasher<User>();
            user.PasswordHash = hasher.HashPassword(user, request.CreateUserDto.Password);


            await _userRepository.AddAsync(user, cancellationToken);

            var userDto = UserDtoMapper.Map(user);

            return OperationResult<UserDto>.Success(userDto);
        }
    }
}
