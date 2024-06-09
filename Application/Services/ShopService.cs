using Application.Contracts;
using Application.Dto;
using Application.Mapper;
using Domain.Models.Users;

namespace Application.Services;

public class ShopService : IShopService
{
    private readonly IShopRepository _userRepository;
    public ShopService(IShopRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task AddUser(AddUserRequestDto requestDto)
    {
        try
        {
            var user = requestDto.AddUserMapper();
            await _userRepository.AddUser(user);
            await _userRepository.Save();
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to add user", ex);
        }
    }

    public async Task<GetUserResponseDto> GetUser(long userId)
    {
        var user = await _userRepository.GetUser(userId);
        if (user == null) throw new Exception("User not found");
        return user.GetUserMapper();
    }

    public async Task DeleteUser(long userId)
    {
        var user = await _userRepository.GetUser(userId);
        if (user == null) throw new Exception("user not found");
        await _userRepository.DeleteUser(user);
        await _userRepository.Save();
    }
}