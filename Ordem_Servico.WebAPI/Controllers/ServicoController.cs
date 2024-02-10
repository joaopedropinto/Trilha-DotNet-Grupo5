using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ordem_Servico.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ServicoController : ControllerBase
{
    private readonly List <Servico> _servicos = new List<Servico>
    {
        new Servico { ServicoID = 1, Data = DateTime.Now, Descricao = "Troca de óleo", Valor = 100.00 },
        new Servico { ServicoID = 2, Data = DateTime.Now, Descricao = "Troca de pneu", Valor = 200.00 },
        new Servico { ServicoID = 3, Data = DateTime.Now, Descricao = "Troca de freio", Valor = 300.00 }
    };

    [HttpGet("servicos")]
    public IActionResult Get()
    {
        return Ok(_servicos);
    }

    [HttpGet("servicos/{id}")]
    public IActionResult Get(int id)
    {
        var servico = _servicos.FirstOrDefault(s => s.ServicoID == id);
        if (servico == null)
        {
            return NotFound();
        }
        return Ok(servico);
    }

    [HttpPost("servicos")]
    public IActionResult Post(Servico servico)
    {
        _servicos.Add(servico);
        return CreatedAtAction(nameof(Get), new { id = servico.ServicoID }, servico);
    }

    [HttpPut("servicos/{id}")]
    public IActionResult Put(int id, Servico servico)
    {
        var servicoExistente = _servicos.FirstOrDefault(s => s.ServicoID == id);
        if (servicoExistente == null)
        {
            return NotFound();
        }
        servicoExistente.Data = servico.Data;
        servicoExistente.Descricao = servico.Descricao;
        servicoExistente.Valor = servico.Valor;
        return NoContent();
    }

    [HttpDelete("servicos/{id}")]
    public IActionResult Delete(int id)
    {
        var servico = _servicos.FirstOrDefault(s => s.ServicoID == id);
        if (servico == null)
        {
            return NotFound();
        }
        _servicos.Remove(servico);
        return NoContent();
    }
}

