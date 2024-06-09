namespace Application.Dto;

public class AddUserProfileRequestDto
{
    public long UserId { get; set; }
    public string? Bio { get; set; }
    public string? Address { get; set; }
}