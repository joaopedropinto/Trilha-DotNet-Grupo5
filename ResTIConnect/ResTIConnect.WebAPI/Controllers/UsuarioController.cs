using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;

namespace ResTIConnect.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet("usuarios")]
    public IActionResult Get()
    {
        var usuarios =  _usuarioService.GetAll();
        return Ok(usuarios);
    }

    [HttpGet("usuarios/{id}")]
    public IActionResult GetById(int id)
    {
        var usuario = _usuarioService.GetById(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }

    [HttpPost("usuarios")]
    public IActionResult Post([FromBody] NewUsuarioInputModel usuario)
    {
        var id = _usuarioService.Create(usuario);
        return CreatedAtAction(nameof(GetById), new { id = id }, usuario);
    }

    [HttpPut("usuarios/{id}")]
    public IActionResult Put(int id, [FromBody] NewUsuarioInputModel usuario)
    {
        _usuarioService.Update(id, usuario);
        return Ok(_usuarioService.GetById(id));
    }

    [HttpDelete("usuarios/{id}")]
    public IActionResult Delete(int id)
    {
        _usuarioService.Delete(id);
        return NoContent();
    }

}
