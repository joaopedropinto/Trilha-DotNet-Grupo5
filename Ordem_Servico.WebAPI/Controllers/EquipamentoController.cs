using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Domain;

namespace Ordem_Servico.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class EquipamentoController : ControllerBase
{
    private readonly List<Equipamento> _equipamentos = new List<Equipamento>();

    [HttpGet("equipamentos")]
    public IActionResult Get()
    {
        return Ok(_equipamentos);
    }

    [HttpGet("equipamento/{id}")]
    public IActionResult GetById(int id)
    {
        var equipamento = _equipamentos.FirstOrDefault(e => e.EquipamentoID == id);
        if (equipamento == null)
        {
            return NotFound();
        }
        return Ok(equipamento);
    }

    [HttpPost("equipamento")]

    public IActionResult Post([FromBody] Equipamento equipamento)
    {
        if (equipamento == null)
        {
            return BadRequest();
        }

        _equipamentos.Add(equipamento);
        return CreatedAtAction(nameof(GetById), new { id = equipamento.EquipamentoID }, equipamento);
    }

    [HttpPut("equipamento/{id}")]
    public IActionResult Put(int id, [FromBody] Equipamento equipamento)
    {
        var existingEquipamento = _equipamentos.FirstOrDefault(e => e.EquipamentoID == id);
        if (existingEquipamento == null)
        {
            return NotFound();
        }

        existingEquipamento.Tipo = equipamento.Tipo;
        existingEquipamento.Marca = equipamento.Marca;
        existingEquipamento.Modelo = equipamento.Modelo;
        existingEquipamento.DadosAdicionais = equipamento.DadosAdicionais;
        existingEquipamento.DefeitoDeclarado = equipamento.DefeitoDeclarado;
        existingEquipamento.Solucao = equipamento.Solucao;

        return Ok(existingEquipamento);
    }

    [HttpDelete("equipamento/{id}")]

    public IActionResult Delete(int id)
    {
        var equipamento = _equipamentos.FirstOrDefault(e => e.EquipamentoID == id);
        if (equipamento == null)
        {
            return NotFound();
        }

        _equipamentos.Remove(equipamento);
        return NoContent();
    }
}