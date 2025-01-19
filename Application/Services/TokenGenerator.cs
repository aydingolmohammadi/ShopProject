using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Models.Users;
using Microsoft.IdentityModel.Tokens;

namespace ShopProject.Application.Services;

public class TokenGenerator
{
    private readonly Config _config;
    public TokenGenerator(Config config)
    {
        _config = config;
    }

    public string GenerateTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username)
        };

        var token = new JwtSecurityToken(
            issuer: _config.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key)),
                algorithm: SecurityAlgorithms.HmacSha256
            )
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}