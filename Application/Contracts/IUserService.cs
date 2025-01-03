using Application.Dto;
using Domain.Models.Users;

namespace Application.Contracts;

public interface IUserService
{
    Task<RegisterUserResDto> RegisterUser(RegisterUserReqDto registerUserReqDto);

    Task<GetUserByIdResDto> GetUserById(long userId);
    IEnumerable<GetUserByIdResDto> GetAllUsers();
    Task UpdateUser(UpdateUserReqDto updateUserReqDto);

    Task DeleteUser(long userId);
}