namespace EcommerceAPI.Application.Common.Models;

public sealed record AuthResult(
    Guid UserId,
    string Email,
    string FirstName,
    string LastName,
    string AccessToken,
    string RefreshToken,
    DateTime ExpiresAtUtc
);
