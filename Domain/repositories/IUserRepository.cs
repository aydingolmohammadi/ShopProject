using Domain.Models.Users;

public interface IUserRepository
{
    Task RegisterUser(User user);
    Task<User?> GetUserById(long userId);
    Task<User?> FindUser(User user);
    IEnumerable<User> GetAllUsers();
    Task DeleteUser(User user);
    Task Save();
}