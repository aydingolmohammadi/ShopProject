using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Models.Users;
using Microsoft.IdentityModel.Tokens;

public class JwtHelper
{
    private readonly string _issuer;
    private readonly string _audience;
    private readonly string _key;

    public JwtHelper(string issuer, string audience, string key)
    {
        _issuer = issuer;
        _audience = audience;
        _key = key;
    }

    public string GenerateTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username)
        };

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
                algorithm: SecurityAlgorithms.HmacSha256
            )
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}