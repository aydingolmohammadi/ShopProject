using Domain.Models.Users;

public interface IUserRepository
{
    Task RegisterUser(User user);
    Task<User?> GetUserById(long userId);
    IEnumerable<User> GetAllUsers();
    Task DeleteUser(User user);
    Task Save();
}