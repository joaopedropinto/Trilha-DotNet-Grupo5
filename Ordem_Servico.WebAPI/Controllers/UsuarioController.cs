using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.WebAPI.Controllers;
[ApiController]
[Route("/api/v0.1/")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService service) => _usuarioService = service;

    [HttpGet("usuarios")]
    public IActionResult Get()
    {
        return Ok(_usuarioService.GetAll());
    }

    [HttpGet("usuario/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var usuario = _usuarioService.GetById(id);
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("usuario")]
    public IActionResult Post([FromBody] NewUsuarioInputModel usuario)
    {
        _usuarioService.Create(usuario);
        return CreatedAtAction(nameof(Get), usuario);
    }

    [HttpPut("usuario/{id}")]
    public IActionResult Put(int id, [FromBody] NewUsuarioInputModel usuario)
    {
        if (_usuarioService.GetById(id) == null)
            return NoContent();
        _usuarioService.Update(id, usuario);
        return Ok(_usuarioService.GetById(id));
    }

    [HttpDelete("usuario/{id}")]
    public IActionResult Delete(int id)
    {
        if (_usuarioService.GetById(id) == null)
            return NoContent();
        _usuarioService.Delete(id);
        return Ok();
    }
}
