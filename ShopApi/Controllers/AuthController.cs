using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ShopProject.Application.Contracts;
using ShopProject.Application.Dto;
using Domain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ShopApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("RegisterUser")]
    public async Task<ActionResult<RegisterUserResDto>> RegisterUser([FromBody] RegisterUserReqDto reqDto)
    {
        var user = await _userService.RegisterUser(reqDto);
        return Ok(user);
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