using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Domain;

namespace Ordem_Servico.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class TecnicoController : ControllerBase
{
    private static List<Tecnico> _tecnicos = new List<Tecnico>
        {
            new Tecnico { TecnicoID = 1, Nome = "Técnico 1" },
            new Tecnico { TecnicoID = 2, Nome = "Técnico 2" },
            new Tecnico { TecnicoID = 3, Nome = "Técnico 3" },
            new Tecnico { TecnicoID = 4, Nome = "Técnico 4" },
            new Tecnico { TecnicoID = 5, Nome = "Técnico 5" }
        };

    [HttpGet("tecnicos")]
    public IActionResult Get()
    {
        return Ok(_tecnicos);
    }

    [HttpGet("tecnico/{id}")]
    public IActionResult GetById(int id)
    {
        var tecnico = _tecnicos.FirstOrDefault(t => t.TecnicoID == id);
        if (tecnico == null)
            return NotFound();

        return Ok(tecnico);
    }

    [HttpPost("tecnico")]
    public IActionResult Post([FromBody] Tecnico tecnico)
    {
        tecnico.TecnicoID = _tecnicos.Count + 1;
        _tecnicos.Add(tecnico);
        return CreatedAtAction(nameof(GetById), new { id = tecnico.TecnicoID }, tecnico);

    }

    [HttpPut("tecnico/{id}")]
    public IActionResult Put(int id, [FromBody] Tecnico tecnico)
    {
        var existingTecnico = _tecnicos.FirstOrDefault(t => t.TecnicoID == id);
        if (existingTecnico == null)
            return NotFound();

        existingTecnico.Nome = tecnico.Nome;
        return NoContent();
    }

    [HttpDelete("tecnico/{id}")]
    public IActionResult Delete(int id)
    {
        var existingTecnico = _tecnicos.FirstOrDefault(t => t.TecnicoID == id);
        if (existingTecnico == null)
            return NotFound();

        _tecnicos.Remove(existingTecnico);
        return NoContent();
    }
}
