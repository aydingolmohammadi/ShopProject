using Application.Dto;
using Domain.Models.Users;

namespace Application.Contracts;

public interface IShopService
{
    Task AddUser(AddUserRequestDto addUserRequestDto);

    Task<GetUserResponseDto> GetUser(long userId);
    IEnumerable<GetUserResponseDto> GetAllUsers();
    Task UpdateUser(UpdateUserRequestDto updateUserRequestDto);

    Task DeleteUser(long userId);
}