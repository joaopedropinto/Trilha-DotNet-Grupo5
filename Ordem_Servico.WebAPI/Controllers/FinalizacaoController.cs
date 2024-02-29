using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
[Authorize]
public class FinalizacaoController : ControllerBase
{
    private readonly IFinalizacaoService _finalizacaoService;
    public FinalizacaoController(IFinalizacaoService service) => _finalizacaoService = service;

    [HttpGet("finalizacoes")]
    public IActionResult Get()
    {
        return Ok(_finalizacaoService.GetAll());
    }

    [HttpGet("finalizacao/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var finalizacao = _finalizacaoService.GetById(id);
            return Ok(finalizacao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("finalizacao")]
    public IActionResult Post([FromBody] NewFinalizacaoInputModel finalizacao)
    {
        if (finalizacao is null)
            return BadRequest();

        _finalizacaoService.Create(finalizacao);
        return CreatedAtAction(nameof(Get), finalizacao);
    }

    [HttpPut("finalizacao/{id}")]
    public IActionResult Put(int id, [FromBody] NewFinalizacaoInputModel finalizacao)
    {
        if (_finalizacaoService.GetById(id) == null)
            return NoContent();

        _finalizacaoService.Update(id, finalizacao);
        return Ok(_finalizacaoService.GetById(id));
    }

    [HttpDelete("finalizacao/{id}")]
    public IActionResult Delete(int id)
    {
        _finalizacaoService.Delete(id);
        return Ok();
    }

}
