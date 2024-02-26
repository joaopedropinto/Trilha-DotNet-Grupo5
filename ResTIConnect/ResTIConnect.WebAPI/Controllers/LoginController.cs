using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;

namespace ResTIConnect.WebAPI.Controllers;
[ApiController]
[Route("/api/v0.1/")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] NewLoginInputModel login)
    {
        var usuario = await _loginService.Authenticate(login);
        if (usuario == null)
        {
            return Unauthorized();
        }
        return Ok(usuario);
    }
}

