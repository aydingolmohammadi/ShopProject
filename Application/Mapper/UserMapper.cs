using Application.Dto;
using Domain.Models.Users;

namespace Application.Mapper;

public static class UserMapper
{
    public static User AddUserMapper(this AddUserRequestDto requestDto) => new User
    {
        Username = requestDto.Username,
        Mobile = requestDto.Mobile,
        Profile = CreateProfile(requestDto.Profile)
    };

    public static GetUserResponseDto GetUserMapper(this User user) => new GetUserResponseDto
    {
        UserId = user.UserId,
        Username = user.Username,
        Mobile = user.Mobile,
        Profile = GetProfileResponseMapper(user.Profile)
    };

    private static Profile CreateProfile(AddUserProfileRequestDto profileDto)
    {
        return new Profile
        {
            UserId = profileDto.UserId,
            Address = profileDto.Address,
            Bio = profileDto.Bio
        };
    }

    private static GetUserProfileResponseDto GetProfileResponseMapper(Profile profile)
    {
        return new GetUserProfileResponseDto
        {
            Id = profile.Id,
            Address = profile.Address,
            Bio = profile.Bio
        };
    }
}
