using CleanArcNetBackendBoilerplate.Application.Commons.OperationResult;
using CleanArcNetBackendBoilerplate.Application.Feature.AuthFeature.Dtos;
using CleanArcNetBackendBoilerplate.Domain.Entities;
using CleanArcNetBackendBoilerplate.Domain.Interfaces;
using CleanArcNetBackendBoilerplate.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArcNetBackendBoilerplate.Application.Feature.AuthFeature.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, OperationResult<LoginResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly PasswordHasher<User> _passwordHasher;

        public LoginCommandHandler(IUserRepository userRepository, ITokenService tokenService, PasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<OperationResult<LoginResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var email = new Email(request.LoginRequestDto.Email);
            var user = await _userRepository.GetByEmailAsync(email, cancellationToken);
            if (user == null)
            {
                return OperationResult<LoginResponseDto>.Failure("Invalid email or password.");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.LoginRequestDto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return OperationResult<LoginResponseDto>.Failure("Invalid email or password.");
            }

            var token = _tokenService.GenerateJwtToken(user);

            var loginResponseDto = new LoginResponseDto
            {
                Token = token,
                UserId = user.Id,
            };

            return OperationResult<LoginResponseDto>.Success(loginResponseDto);
        }
    }
}
