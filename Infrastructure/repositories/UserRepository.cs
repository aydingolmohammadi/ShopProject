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

    public async Task AddUser(User user) => await _dbContext.Users.AddAsync(user);
    public async Task<User?> GetUserById(long userId) => await _dbContext.Users.FindAsync(userId);
    public IEnumerable<User> GetAllUsers() => _dbContext.Users.ToList();

    public async Task UpdateUser(User user)
    {
        var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser != null)
        {
            existingUser.Username = user.Username;
            existingUser.Mobile = user.Mobile;
        }
    }

    public async Task DeleteUser(User user) => _dbContext.Users.Remove(user);
    public async Task Save() => await _dbContext.SaveChangesAsync();
}