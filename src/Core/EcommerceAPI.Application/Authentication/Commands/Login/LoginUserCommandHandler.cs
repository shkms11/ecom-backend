using EcommerceAPI.Application.Common.Interfaces;
using EcommerceAPI.Application.Common.Models;
using MediatR;

namespace EcommerceAPI.Application.Authentication.Commands.Login;

public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResult>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public LoginUserCommandHandler(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<AuthResult> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken
    )
    {
        // 1. Load user by email
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        // 2. Check credentials
        var validCredentials =
            user is not null
            && await _userRepository.CheckPasswordAsync(user, request.Password, cancellationToken);

        if (!validCredentials)
        {
            // In a real app you’d likely throw a custom exception
            // that your global exception middleware maps to 401.
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        // 3. Generate tokens
        var accessToken = _tokenService.GenerateAccessToken(user!);
        var refreshToken = _tokenService.GenerateRefreshToken(user!);
        var expiresAtUtc = _tokenService.GetAccessTokenExpiryUtc();

        // 4. Map to AuthResult (Application-level DTO)
        return new AuthResult(
            UserId: user!.Id,
            Email: user.Email,
            FirstName: user.FirstName,
            LastName: user.LastName,
            AccessToken: accessToken,
            RefreshToken: refreshToken,
            ExpiresAtUtc: expiresAtUtc
        );
    }
}
