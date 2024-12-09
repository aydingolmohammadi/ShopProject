using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.repositories;

public class UserRepository : IUserRepository
{
    private readonly DataBaseContext _dbContext;

    public UserRepository(DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task RegisterUser(User user) => await _dbContext.Users.AddAsync(user);
    public async Task<User?> GetUserById(long userId) => await _dbContext.Users.FindAsync(userId);
    public Task<User?> FindUser(User user) => _dbContext.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

    public IEnumerable<User> GetAllUsers() => _dbContext.Users.ToList();
    public async Task DeleteUser(User user) => _dbContext.Users.Remove(user);
    public async Task Save() => await _dbContext.SaveChangesAsync();
}