using Domain.Models.Users;
using ShopProject.Application.Dto;

namespace ShopProject.Application.Mapper;

public static class UserMapper
{
    public static User Factory(this RegisterUserReqDto registerUserReqDto) => new User
    {
        Username = registerUserReqDto.Username,
        Password = registerUserReqDto.Password
    };

    public static GetUserByIdResDto Factory(this User user) => new GetUserByIdResDto
    {
        Id = user.Id,
        Username = user.Username,
    };
}