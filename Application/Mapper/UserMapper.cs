using Application.Dto;
using Domain.Models.Users;

namespace Application.Mapper;

public static class UserMapper
{
    public static User AddUserMapper(this AddUserRequestDto addUserRequestDto) => new User
    {
        Username = addUserRequestDto.Username,
        Mobile = addUserRequestDto.Mobile
    };

    public static GetUserResponseDto GetUserMapper(this User user) => new GetUserResponseDto
    {
        Id = user.Id,
        Username = user.Username,
        Mobile = user.Mobile
    };

    public static User UpdateUserMapper(this UpdateUserRequestDto updateUserRequestDto) => new User
    {
        Id = updateUserRequestDto.Id,
        Username = updateUserRequestDto.Username,
        Mobile = updateUserRequestDto.Mobile
    };
}