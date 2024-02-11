using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;

namespace Ordem_Servico.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class PecaController : ControllerBase
{
    private readonly IPecaService _pecaService;

    public PecaController(IPecaService service) => _pecaService = service;

    [HttpGet("pecas")]
    public IActionResult Get()
    {
        return Ok(_pecaService.GetAll());
    }

    [HttpGet("peca/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var peca = _pecaService.GetById(id);
            return Ok(peca);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("peca")]
    public IActionResult Post([FromBody] NewPecaInputModel peca)
    {
        if (peca is null)
            return BadRequest();

        _pecaService.Create(peca);
        return CreatedAtAction(nameof(Get), peca);
    }

    [HttpPut("peca/{id}")]
    public IActionResult Put(int id, [FromBody] NewPecaInputModel peca)
    {
        if (_pecaService.GetById(id) == null)
            return NoContent();

        _pecaService.Update(id, peca);
        return Ok(_pecaService.GetById(id));
    }

    [HttpDelete("peca/{id}")]
    public IActionResult Delete(int id)
    {
        _pecaService.Delete(id);
        return Ok();
    }

}
