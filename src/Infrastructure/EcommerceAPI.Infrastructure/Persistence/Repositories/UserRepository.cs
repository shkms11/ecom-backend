using EcommerceAPI.Application.Common.Interfaces;
using EcommerceAPI.Domain.Entities;
using EcommerceAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default
    )
    {
        return await _context.Users.FirstOrDefaultAsync(
            user => user.Email == email,
            cancellationToken
        );
    }

    public async Task<bool> CheckPasswordAsync(
        User user,
        string password,
        CancellationToken cancellationToken = default
    )
    {
        // TODO: use your existing password hashing implementation here.
        throw new NotImplementedException();
    }

    public async Task CreateAsync(
        User user,
        string password,
        CancellationToken cancellationToken = default
    )
    {
        // TODO: use your existing password hashing implementation here.
        throw new NotImplementedException();
    }
}
