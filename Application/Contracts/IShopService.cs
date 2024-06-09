using Application.Dto;

namespace Application.Contracts;

public interface IShopService
{
    Task AddUser(AddUserRequestDto requestDto);

    Task<GetUserResponseDto> GetUser(long userId);

    Task DeleteUser(long userId);
}