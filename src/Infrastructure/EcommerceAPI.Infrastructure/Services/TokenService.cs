using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EcommerceAPI.Application.Common.Interfaces;
using EcommerceAPI.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EcommerceAPI.Infrastructure.Services;

public sealed class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateAccessToken(User user)
    {
        var jwtSettings = _configuration.GetSection("Jwt");

        var key =
            jwtSettings["Key"] ?? throw new InvalidOperationException("JWT Key is not configured.");

        var issuer =
            jwtSettings["Issuer"]
            ?? throw new InvalidOperationException("JWT Issuer is not configured.");

        var audience =
            jwtSettings["Audience"]
            ?? throw new InvalidOperationException("JWT Audience is not configured.");

        var expirationValue = jwtSettings["AccessTokenExpirationMinutes"];

        var expiresInMinutes = string.IsNullOrWhiteSpace(expirationValue)
            ? 60
            : int.Parse(expirationValue);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim("firstName", user.FirstName),
            new Claim("lastName", user.LastName),
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiresInMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken(User user)
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

    public DateTime GetAccessTokenExpiryUtc()
    {
        var expirationValue = _configuration.GetSection("Jwt")["AccessTokenExpirationMinutes"];

        var expiresInMinutes = string.IsNullOrWhiteSpace(expirationValue)
            ? 60
            : int.Parse(expirationValue);

        return DateTime.UtcNow.AddMinutes(expiresInMinutes);
    }
}
