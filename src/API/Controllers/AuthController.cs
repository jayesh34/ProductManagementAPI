using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var response = await _authService.LoginAsync(request);

        if (response == null)
        {
            return Unauthorized(new
            {
                message = "Invalid username or password."
            });
        }

        return Ok(response);
    }

[HttpPost("refresh")]
public async Task<IActionResult> RefreshToken(
    RefreshTokenRequestDto request)
{
    var response = await _authService.RefreshTokenAsync(request);

    if (response == null)
        return Unauthorized();

    return Ok(response);
}
}