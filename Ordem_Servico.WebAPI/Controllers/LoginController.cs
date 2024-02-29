using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.InputModels;

namespace Ordem_Servico.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService service) => _loginService = service;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] NewLoginInputModel login)
        {
            var usuario = _loginService.Authenticate(login);
            if (usuario == null)
                return Unauthorized();
            return Ok(usuario);
        }

    }
}
