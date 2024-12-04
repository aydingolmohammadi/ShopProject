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
    public async Task AddUser(AddUserRequestDto addUserRequestDto)
    {
        try
        {
            var user = addUserRequestDto.AddUserMapper();
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

    public IEnumerable<GetUserResponseDto> GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();
        return users.Select(u => u.GetUserMapper()).ToList();
    }

    public async Task UpdateUser(UpdateUserRequestDto updateUserRequestDto)
    {
        var user = updateUserRequestDto.UpdateUserMapper();
        if (await _userRepository.GetUser(user.Id) == null) throw new Exception("User not found");
        await _userRepository.UpdateUser(user);
        await _userRepository.Save();
    }

    public async Task DeleteUser(long userId)
    {
        var user = await _userRepository.GetUser(userId);
        if (user == null) throw new Exception("user not found");
        await _userRepository.DeleteUser(user);
        await _userRepository.Save();
    }
}