using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ResTIConnect.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
[Authorize]
public class EventoController : ControllerBase
{
    private readonly IEventoService _eventoService;

    public EventoController(IEventoService eventoService)
    {
        _eventoService = eventoService;
    }

    [HttpGet("eventos")]
    public IActionResult Get()
    {
        var eventos =  _eventoService.GetAll();
        return Ok(eventos);
    }

    [HttpGet("eventos/{id}")]
    public IActionResult GetById(int id)
    {
        var evento = _eventoService.GetById(id);
        if (evento == null)
        {
            return NotFound();
        }
        return Ok(evento);
    }

    [HttpPost("eventos")]
    public IActionResult Post([FromBody] NewEventoInputModel evento)
    {
        var id = _eventoService.Create(evento);
        return CreatedAtAction(nameof(GetById), new { id = id }, evento);
    }

    [HttpPut("eventos/{id}")]
    public IActionResult Put(int id, [FromBody] NewEventoInputModel evento)
    {
        _eventoService.Update(id, evento);
        return Ok(_eventoService.GetById(id));
    }

    [HttpDelete("eventos/{id}")]
    public IActionResult Delete(int id)
    {
        _eventoService.Delete(id);
        return NoContent();
    }
}
