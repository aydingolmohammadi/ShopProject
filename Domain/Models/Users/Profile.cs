namespace Domain.Models.Users;

public class Profile
{
    public string? Bio { get; set; }
    public string? Address { get; set; }
    public long UserId { get; set; }
    public long Id { get; set; }
    public User? User { get; set; }
}