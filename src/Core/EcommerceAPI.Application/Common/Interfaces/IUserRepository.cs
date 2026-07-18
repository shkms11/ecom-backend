using EcommerceAPI.Domain.Entities;

namespace EcommerceAPI.Application.Common.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Returns the user with the specified email, or null if not found.
    /// </summary>
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Verifies the given password against the stored credentials for this user.
    /// </summary>
    Task<bool> CheckPasswordAsync(
        User user,
        string password,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new user with the given password.
    /// </summary>
    Task CreateAsync(User user, string password, CancellationToken cancellationToken = default);
}
