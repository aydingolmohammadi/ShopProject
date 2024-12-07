using Application.Dto;
using Domain.Models.Users;

namespace Application.Mapper;

public static class UserMapper
{
    public static User AddUserMapper(this AddUserReqDto addUserReqDto) => new User
    {
        Username = addUserReqDto.Username,
        Mobile = addUserReqDto.Mobile
    };

    public static GetUserByIdResDto GetUserMapper(this User user) => new GetUserByIdResDto
    {
        Id = user.Id,
        Username = user.Username,
        Mobile = user.Mobile
    };

    public static User UpdateUserMapper(this UpdateUserReqDto updateUserReqDto) => new User
    {
        Id = updateUserReqDto.Id,
        Username = updateUserReqDto.Username,
        Mobile = updateUserReqDto.Mobile
    };
}