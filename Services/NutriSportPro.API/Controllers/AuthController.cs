using Microsoft.AspNetCore.Authorization;
using NutriSportPro.API.Dtos;

namespace NutriSportPro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authService.GetTokenAsync(request);
        if (!result.IsAuthenticated)
        {
            return Unauthorized(result);
        }
        return Ok(result);
    }
}
