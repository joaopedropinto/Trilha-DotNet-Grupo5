using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services;
using Ordem_Servico.Application.Services.Interfaces;

namespace Ordem_Servico.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
[Authorize]
public class OcorrenciaController : ControllerBase
{
    private readonly IOcorrenciaService _ocorrenciaService;

    public OcorrenciaController(IOcorrenciaService ocorrenciaService)
    {
        _ocorrenciaService = ocorrenciaService;
    }

    [HttpGet("ocorrencias")]
    public IActionResult Get()
    {
        return Ok(_ocorrenciaService.GetAll());
    }

    [HttpGet("ocorrencia/{id}")]
    public IActionResult GetById(int id)
    {
        var ocorrencia = _ocorrenciaService.GetById(id);
        if (ocorrencia is null)
        {
            return NotFound();
        }
        return Ok(ocorrencia);
    }

    [HttpPost("ocorrencia")]
    public IActionResult Post([FromBody] NewOcorrenciaInputModel ocorrencia)
    {
        if (ocorrencia is null)
        {
            return BadRequest();
        }

        var id = _ocorrenciaService.Create(ocorrencia);
        return CreatedAtAction(nameof(GetById), new { id }, ocorrencia);
    }

    [HttpPut("ocorrencia/{id}")]
    public IActionResult Put(int id, [FromBody] NewOcorrenciaInputModel ocorrencia)
    {
        if (ocorrencia is null)
        {
            return BadRequest();
        }

        _ocorrenciaService.Update(id, ocorrencia);
        return NoContent();
    }

    [HttpDelete("ocorrencia/{id}")]
    public IActionResult Delete(int id)
    {
        _ocorrenciaService.Delete(id);
        return NoContent();
    }

}
