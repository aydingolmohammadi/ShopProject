using Application.Contracts;
using Application.Dto;
using Application.Mapper;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtHelper _jwtHelper;

    public UserService(IUserRepository userRepository, JwtHelper jwtHelper)
    {
        _userRepository = userRepository;
        _jwtHelper = jwtHelper;
    }

    public async Task<RegisterUserResDto> RegisterUser(RegisterUserReqDto registerUserReqDto)
    {
        var user = registerUserReqDto.Factory();
        if (await _userRepository.FindUser(user) is not null)
        {
            throw new Exception("Username already exists.");
        }

        await _userRepository.RegisterUser(user);
        await _userRepository.Save();

        var token = _jwtHelper.GenerateTokenAsync(user);

        return new RegisterUserResDto
        {
            Token = token
        };
    }

    public async Task<GetUserByIdResDto> GetUserById(long userId)
    {
        var user = await _userRepository.GetUserById(userId);
        if (user == null) throw new Exception("User not found");
        return user.Factory();
    }

    public IEnumerable<GetUserByIdResDto> GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();
        return users.Select(u => u.Factory()).ToList();
    }

    public async Task UpdateUser(UpdateUserReqDto updateUserReqDto)
    {
        var existingUser = await _userRepository.GetUserById(updateUserReqDto.Id);
        if (existingUser == null) throw new Exception("User not found");

        existingUser.Username = updateUserReqDto.Username;
        existingUser.Password = updateUserReqDto.Password;
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