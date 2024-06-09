namespace Application.Dto;

public class GetUserResponseDto
{
    public long UserId { get; set; }
    public string Username { get; set; }
    public string Mobile { get; set; }
    public GetUserProfileResponseDto Profile { get; set; }
}