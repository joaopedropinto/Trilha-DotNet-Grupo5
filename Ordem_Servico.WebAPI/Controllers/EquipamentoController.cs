using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class EquipamentoController : ControllerBase
{
     private readonly IEquipamentoService _equipamentoService;
    public List<EquipamentoViewModel> Equipamentos => _equipamentoService.GetAll();
    public EquipamentoController(IEquipamentoService service) => _equipamentoService = service;

    [HttpGet("equipamentos")]
    public IActionResult Get()
    {
        return Ok(Equipamentos);
    }

    [HttpGet("equipamento/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var equipamento = _equipamentoService.GetById(id);
            return Ok(equipamento);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("equipamento")]
    public IActionResult Post([FromBody] NewEquipamentoInputModel equipamento)
    {
        _equipamentoService.Create(equipamento);
        return CreatedAtAction(nameof(Get), equipamento);
    }

    [HttpPut("equipamento/{id}")]
    public IActionResult Put(int id, [FromBody] NewEquipamentoInputModel equipamento)
    {
        if (_equipamentoService.GetById(id) == null)
            return NoContent();
        _equipamentoService.Update(id, equipamento);
        return Ok(_equipamentoService.GetById(id));
    }

    [HttpDelete("equipamento/{id}")]
    public IActionResult Delete(int id)
    {
        if (_equipamentoService.GetById(id) == null)
            return NoContent();
        _equipamentoService.Delete(id);
        return Ok();
    }
}