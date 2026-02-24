using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Models;

public class RequestContext
{
    public required Guid UserId { get; init; }
    public required string Username { get; init; }
    public required string Role { get; init; }

    public RequestContext(IHttpContextAccessor httpContextAccessor)
    {
        ClaimsPrincipal? user = httpContextAccessor.HttpContext?.User;

        if (user?.Identity?.IsAuthenticated == true)
        {
            UserId = Guid.Parse(user.FindFirst("id")?.Value ?? throw new InvalidOperationException());
            Username = user.FindFirst("name")?.Value ?? throw new InvalidOperationException();
            Role = user.FindFirst("role")?.Value ?? throw new InvalidOperationException();
        }
    }
}
