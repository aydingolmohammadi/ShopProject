using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.repositories;

public class UserRepository(DataBaseContext dbContext) : IUserRepository
{
    public async Task RegisterUser(User user) => await dbContext.Users.AddAsync(user);
    public async Task<User?> GetUserById(long userId) => await dbContext.Users.FindAsync(userId);
    public Task<User?> FindUser(User user) => dbContext.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

    public IEnumerable<User> GetAllUsers() => dbContext.Users.ToList();
    public async Task DeleteUser(User user) => dbContext.Users.Remove(user);
    public async Task Save() => await dbContext.SaveChangesAsync();
}