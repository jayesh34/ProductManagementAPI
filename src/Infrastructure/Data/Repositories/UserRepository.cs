using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
{
    return await _context.Users
        .Include(u => u.RefreshTokens)
        .FirstOrDefaultAsync(u =>
            u.RefreshTokens.Any(r =>
                r.Token == refreshToken &&
                !r.IsRevoked &&
                r.ExpiryDate > DateTime.UtcNow));
}
}