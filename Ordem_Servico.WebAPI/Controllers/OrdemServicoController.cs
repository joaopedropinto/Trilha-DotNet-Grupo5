using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ordem_Servico.WebAPI;

[ApiController]
[Route("/api/v0.1/")]
public class OrdemServicoController : ControllerBase
{
    private readonly List<OrdemServico> _ordensServico = new List<OrdemServico>();

    [HttpGet("ordem_servicos")]
    public ActionResult<IEnumerable<OrdemServico>> Get()
    {
        return _ordensServico;
    }

    [HttpGet("ordem_servico/{id}")]
    public ActionResult<OrdemServico> Get(int id)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        return ordemServico;
    }

    [HttpPost("ordem_servico")]
    public ActionResult<OrdemServico> Post(OrdemServico ordemServico)
    {
        ordemServico.OrdemServicoID = _ordensServico.Count + 1;
        _ordensServico.Add(ordemServico);
        return CreatedAtAction(nameof(Get), new { id = ordemServico.OrdemServicoID }, ordemServico);
    }

    [HttpPut("ordem_servico/{id}")]
    public ActionResult Put(int id, OrdemServico ordemServico)
    {
        if (id != ordemServico.OrdemServicoID)
            return BadRequest();

        var existingOrdemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (existingOrdemServico == null)
            return NotFound();

        _ordensServico[id - 1] = ordemServico;

        return NoContent();
    }

    [HttpDelete("ordem_servico/{id}")]
    public ActionResult Delete(int id)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        _ordensServico.Remove(ordemServico);

        return NoContent();
    }

    [HttpGet("ordem_servico/{id}/ocorrencias")]
    public ActionResult<IEnumerable<Ocorrencia>> GetOcorrencias(int id)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        return Ok(ordemServico.Ocorrencias);
    }

    [HttpPost("ordem_servico/{id}/ocorrencias")]
    public ActionResult AddOcorrencia(int id, Ocorrencia ocorrencia)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        ordemServico?.Ocorrencias?.Add(ocorrencia);

        return CreatedAtAction(nameof(GetOcorrencias), new { id }, ocorrencia);
    }

    [HttpPut("ordem_servico/{id}/ocorrencias/{ocorrenciaId}")]
    public ActionResult UpdateOcorrencia(int id, int ocorrenciaId, Ocorrencia ocorrencia)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        var existingOcorrencia = ordemServico?.Ocorrencias?.FirstOrDefault(o => o.OcorrenciaID == ocorrenciaId);
        if (existingOcorrencia == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("ordem_servico/{id}/ocorrencias/{ocorrenciaId}")]
    public ActionResult DeleteOcorrencia(int id, int ocorrenciaId)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        var ocorrencia = ordemServico?.Ocorrencias?.FirstOrDefault(o => o.OcorrenciaID == ocorrenciaId);
        if (ocorrencia == null)
            return NotFound();

        return NoContent();
    }

    [HttpGet("ordem_servico/{id}/pecas")]
    public ActionResult<IEnumerable<Peca>> GetPecas(int id)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        return Ok(ordemServico.Pecas);
    }

    [HttpPost("ordem_servico/{id}/pecas")]
    public ActionResult AddPeca(int id, Peca peca)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        ordemServico?.Pecas?.Add(peca);

        return CreatedAtAction(nameof(GetPecas), new { id }, peca);
    }

    [HttpPut("ordem_servico/{id}/pecas/{pecaId}")]
    public ActionResult UpdatePeca(int id, int pecaId, Peca peca)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        var existingPeca = ordemServico?.Pecas?.FirstOrDefault(p => p.PecaID == pecaId);
        if (existingPeca == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("ordem_servico/{id}/pecas/{pecaId}")]
    public ActionResult DeletePeca(int id, int pecaId)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        var peca = ordemServico?.Pecas?.FirstOrDefault(p => p.PecaID == pecaId);
        if (peca == null)
            return NotFound();

        return NoContent();
    }

    [HttpGet("ordem_servico/{id}/finalizacao")]
    public ActionResult<Finalizacao> GetFinalizacao(int id)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        return Ok(ordemServico.Finalizacao);
    }

    [HttpPost("ordem_servico/{id}/finalizacao")]
    public ActionResult AddFinalizacao(int id, Finalizacao finalizacao)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        ordemServico.Finalizacao = finalizacao;

        return CreatedAtAction(nameof(GetFinalizacao), new { id }, finalizacao);
    }

    [HttpPut("ordem_servico/{id}/finalizacao")]
    public ActionResult UpdateFinalizacao(int id, Finalizacao finalizacao)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        if (ordemServico.Finalizacao == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("ordem_servico/{id}/finalizacao")]
    public ActionResult DeleteFinalizacao(int id)
    {
        var ordemServico = _ordensServico.FirstOrDefault(os => os.OrdemServicoID == id);
        if (ordemServico == null)
            return NotFound();

        if (ordemServico.Finalizacao == null)
            return NotFound();

        return NoContent();
    }
}