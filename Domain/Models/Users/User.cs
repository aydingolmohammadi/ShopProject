using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Users;

public class User
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string Mobile { get; set; }
}