using Domain.Models.Users;

public interface IUserRepository
{
    Task AddUser(User user);
    Task<User?> GetUserById(long userId);
    IEnumerable<User> GetAllUsers();
    Task UpdateUser(User user);
    Task DeleteUser(User user);
    Task Save();
}