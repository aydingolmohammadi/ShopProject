namespace Domain.Models.Users;

public interface IShopRepository
{
    Task AddUser(User user);
    Task<User?> GetUser(long userId);
    Task DeleteUser(User user);
    Task Save();
}