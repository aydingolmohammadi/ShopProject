using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.repositories;

public class ShopRepository : IShopRepository
{
    private readonly DataBaseContext _dbContext;

    public ShopRepository(DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddUser(User user) => await _dbContext.Users.AddAsync(user);
    public async Task<User?> GetUser(long userId) => await _dbContext.Users.Include(u => u.Profile).FirstOrDefaultAsync(u => u.UserId == userId);
    public async Task DeleteUser(User user) => _dbContext.Users.Remove(user);
    public async Task Save() => await _dbContext.SaveChangesAsync();
}