using Application.Contracts;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ShopApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("AddUser")]
    public async Task<ActionResult<string>> AddUser([FromBody] AddUserReqDto reqDto)
    {
        await _userService.AddUser(reqDto);
        return Ok("User added successfully");
    }

    [HttpGet("GetUserById")]
    public async Task<ActionResult<GetUserByIdResDto>> GetUser(long userId)
    {
        return Ok(await _userService.GetUserById(userId));
    }

    [HttpGet("GetAllUser")]
    public ActionResult<ICollection<GetUserByIdResDto>> GetUser()
    {
        return Ok(_userService.GetAllUsers());
    }

    [HttpPut("UpdateUser")]
    public async Task<ActionResult<string>> UpdateUser([FromBody] UpdateUserReqDto updateUserReqDto)
    {
        await _userService.UpdateUser(updateUserReqDto);
        return Ok("User updated successfully");
    }

    [HttpDelete("DeleteUser")]
    public async Task<ActionResult<string>> DeleteUser(long userId)
    {
        await _userService.DeleteUser(userId);
        return Ok("User delete successfully");
    }
}