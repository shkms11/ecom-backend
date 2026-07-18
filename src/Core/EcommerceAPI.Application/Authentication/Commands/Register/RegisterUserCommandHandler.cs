using EcommerceAPI.Application.Common.Interfaces;
using EcommerceAPI.Application.Common.Models;
using EcommerceAPI.Domain.Entities;
using MediatR;

namespace EcommerceAPI.Application.Authentication.Commands.Register;

public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthResult>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public RegisterUserCommandHandler(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<AuthResult> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken
    )
    {
        // 1. Check if email already exists
        var existingUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser is not null)
        {
            // In a real app: custom exception mapped to 409 Conflict or 400
            throw new InvalidOperationException("Email is already registered.");
        }

        // 2. Create domain user
        var user = new User(
            email: request.Email,
            firstName: request.FirstName,
            lastName: request.LastName
        );

        // 3. Persist user with password
        await _userRepository.CreateAsync(user, request.Password, cancellationToken);

        // 4. Generate tokens
        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken(user);
        var expiresAtUtc = _tokenService.GetAccessTokenExpiryUtc();

        // 5. Return AuthResult for API/frontend
        return new AuthResult(
            UserId: user.Id,
            Email: user.Email,
            FirstName: user.FirstName,
            LastName: user.LastName,
            AccessToken: accessToken,
            RefreshToken: refreshToken,
            ExpiresAtUtc: expiresAtUtc
        );
    }
}
