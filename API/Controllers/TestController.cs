using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController(
    TestService testService,
    RequestContext requestContext
) : ControllerBase
{
    [HttpGet]
    [Authorize]
    [Route("admin/token")]
    public IActionResult GetAdminToken()
    {
        return Ok(testService.GenerateToken("Admin"));
    }

    [HttpGet]
    [Authorize]
    [Route("user/token")]
    public IActionResult GetUserToken()
    {
        return Ok(testService.GenerateToken("User"));
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route("admin")]
    public IActionResult GetAdmin()
    {
        return Ok("Admin access granted");
    }

    [HttpGet]
    [Authorize(Roles = "User")]
    [Route("user")]
    public IActionResult GetUser()
    {
        return Ok("User access granted");
    }

    [HttpGet]
    [Authorize]
    [Route("authenticated")]
    public IActionResult GetAuthenticated()
    {
        return Ok($"Authenticated access granted.\n{requestContext.UserId} {requestContext.Username} {requestContext.Role}");
    }
}
