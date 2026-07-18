using EcommerceAPI.Domain.Entities;

namespace EcommerceAPI.Application.Common.Interfaces;

public interface ITokenService
{
    /// <summary>
    /// Generates a JWT access token for the specified user.
    /// </summary>
    string GenerateAccessToken(User user);

    /// <summary>
    /// Generates a refresh token for the specified user.
    /// </summary>
    string GenerateRefreshToken(User user);

    /// <summary>
    /// Returns the UTC expiry time for newly generated access tokens.
    /// </summary>
    DateTime GetAccessTokenExpiryUtc();
}
