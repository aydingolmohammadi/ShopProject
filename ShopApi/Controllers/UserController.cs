using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Contracts;
using Application.Dto;
using Domain.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ShopApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public UserController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("RegisterUser")]
    public async Task<IActionResult> RegisterUser([FromBody] AddUserReqDto reqDto)
    {
        var user = await _userService.RegisterUser(reqDto);

        if (user == null)
        {
            return BadRequest("User registration failed");
        }

        var token = await GenerateTokenAsync(user);

        return Ok(new
        {
            Id = user.Id,
            Username = user.Username,
            Mobile = user.Mobile,
            Token = token
        });
    }

    private async Task<string> GenerateTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var token = new JwtSecurityToken(
            "http://localhost:5295",
            "http://localhost:5295",
            claims,
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("S132ASDD132DGF89DSFDFGG4789SA3213KKJBDFVV")),
                algorithm: SecurityAlgorithms.HmacSha256
            )
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
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