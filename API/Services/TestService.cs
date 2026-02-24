using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class TestService(
    IOptions<AuthenticationOptions> authenticationOptions
    )
{
    public string GenerateToken(string role)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationOptions.Value.Secret));
        SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims =
        [
            new ("id", Guid.NewGuid().ToString()),
            new ("name", "username"),
            new ("role", role)
        ];

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = credentials,
            Issuer = authenticationOptions.Value.Issuer,
            Audience = authenticationOptions.Value.Audience
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
