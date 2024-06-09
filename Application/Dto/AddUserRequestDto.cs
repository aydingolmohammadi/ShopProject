namespace Application.Dto;

public class AddUserRequestDto
{
    public string Username { get; set; }
    public string Mobile { get; set; }
    
    public AddUserProfileRequestDto Profile { get; set; }
}