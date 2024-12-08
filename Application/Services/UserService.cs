using Application.Contracts;
using Application.Dto;
using Application.Mapper;
using Domain.Models.Users;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> RegisterUser(AddUserReqDto addUserReqDto)
    {
        try
        {
            var user = addUserReqDto.AddUserMapper();
            await _userRepository.RegisterUser(user);
            await _userRepository.Save();
            return user;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to add user", ex);
        }
    }

    public async Task<GetUserByIdResDto> GetUserById(long userId)
    {
        var user = await _userRepository.GetUserById(userId);
        if (user == null) throw new Exception("User not found");
        return user.GetUserMapper();
    }

    public IEnumerable<GetUserByIdResDto> GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();
        return users.Select(u => u.GetUserMapper()).ToList();
    }

    public async Task UpdateUser(UpdateUserReqDto updateUserReqDto)
    {
        var existingUser = await _userRepository.GetUserById(updateUserReqDto.Id);
        if (existingUser == null) throw new Exception("User not found");

        existingUser.Username = updateUserReqDto.Username;
        existingUser.Mobile = updateUserReqDto.Mobile;
        await _userRepository.Save();
    }

    public async Task DeleteUser(long userId)
    {
        var user = await _userRepository.GetUserById(userId);
        if (user == null) throw new Exception("user not found");
        await _userRepository.DeleteUser(user);
        await _userRepository.Save();
    }
}