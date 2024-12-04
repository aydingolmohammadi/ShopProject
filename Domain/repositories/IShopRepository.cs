using Domain.Models.Users;

public interface IShopRepository
{
    Task AddUser(User user);
    Task<User?> GetUser(long userId);
    IEnumerable<User> GetAllUsers();
    Task UpdateUser(User user);
    Task DeleteUser(User user);
    Task Save();
}