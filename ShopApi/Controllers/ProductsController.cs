using Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShopApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<ProductsResDto>> Products()
    {
        return Ok(new ProductsResDto()
        {
            Name = "Watch",
            Description = "Watch product by name and description.",
            Price = 1200000.0
        });
    }
}