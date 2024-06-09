namespace Domain.Models.Users;

public class User
{
    public long UserId { get; set; }
    public string Username { get; set; }
    public string Mobile { get; set; }
    public Profile Profile { get; set; }
}