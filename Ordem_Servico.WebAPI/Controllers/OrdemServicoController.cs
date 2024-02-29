using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.WebAPI;

[ApiController]
[Route("/api/v0.1/")]
[Authorize]
public class OrdemServicoController : ControllerBase
{
    private readonly IOrdemServicoService _ordemServicoService;

    public OrdemServicoController(IOrdemServicoService ordemServicoService)
    {
        _ordemServicoService = ordemServicoService;
    }

    [HttpGet("ordem_servicos")]
    public ActionResult<IEnumerable<OrdemServicoViewModel>> Get()
    {
        return Ok(_ordemServicoService.GetAll());
    }

    [HttpGet("ordem_servico/{id}")]
    public ActionResult<OrdemServicoViewModel> Get(int id)
    {
        var ordemServico = _ordemServicoService.GetById(id);
        if (ordemServico == null)
            return NotFound();

        return Ok(ordemServico);
    }

    [HttpPost("ordem_servico")]
    public ActionResult<OrdemServicoViewModel> Post([FromBody] NewOrdemServicoInputModel ordemServico)
    {
        if (ordemServico is null)
            return BadRequest();

        var id = _ordemServicoService.Create(ordemServico);
        
        return CreatedAtAction(nameof(Get), new { id }, ordemServico);
    }

    [HttpPut("ordem_servico/{id}")]
    public ActionResult Put(int id, [FromBody] NewOrdemServicoInputModel ordemServico)
    {
        if (ordemServico is null)
            return BadRequest();

        _ordemServicoService.Update(id, ordemServico);
        return NoContent();
    }

    [HttpDelete("ordem_servico/{id}")]
    public ActionResult Delete(int id)
    {
        _ordemServicoService.Delete(id);
        return NoContent();
    }
}