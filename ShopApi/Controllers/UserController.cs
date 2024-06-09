using Application.Contracts;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ShopApi.Controllers;

[ApiController]
[Route("api/User")]
public class UserController : ControllerBase
{
    private readonly IShopService _shopService;
    public UserController(IShopService shopService)
    {
        _shopService = shopService;
    }
    [HttpPost("AddUser")]
    public async Task<ActionResult<string>> AddUser([FromBody] AddUserRequestDto requestDto)
    {
        await _shopService.AddUser(requestDto);
        return Ok("User added successfully");
    }
    
    [HttpGet("GetUser")]
    public async Task<ActionResult<GetUserResponseDto>> GetUser(long userId)
    {
        return Ok(await _shopService.GetUser(userId));
    }

    [HttpDelete("DeleteUser")]
    public async Task<ActionResult<string>> DeleteUser(long userId)
    {
        await _shopService.DeleteUser(userId);
        return Ok("User delete successfully");
    }
}