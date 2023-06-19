using Communications.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticateController : ControllerBase
{
    private readonly IAuthenticateService _authenticateService;

    public AuthenticateController(IAuthenticateService authenticateService)
    {
        _authenticateService = authenticateService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthenticateRequest authenticateRequest)
    {
        var (success, result) =
            await _authenticateService.Login(authenticateRequest.Username, authenticateRequest.Password);
        if (!success) return Ok("Login failed");
        return Ok("Login successfully");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(AuthenticateRequest authenticateRequest)
    {
        var (success, result) =
            await _authenticateService.Register(authenticateRequest.Username, authenticateRequest.Password);
        if (!success) return Ok("Register failed");
        return Ok("Register successfully");
    }
}