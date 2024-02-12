using Microsoft.AspNetCore.Mvc;
using Ordem_Servico.Application.Services.Interfaces;

namespace Ordem_Servico.WebAPI.Controllers;

[ApiController]
[Route("api/0.1")]
public class RelatorioController : ControllerBase
{
    private readonly IRelatorioService _relatorioService;

    public RelatorioController(IRelatorioService relatorioService)
    {
        _relatorioService = relatorioService;
    }

    [HttpGet("relatorio/ordens-servico/status/{status}")]
    public IActionResult GetOrdensServicoPorStatus(string status)
    {
        var ordensServico = _relatorioService.GetOrdensServicoPorStatus(status);
        return Ok(ordensServico);
    }

    [HttpGet("relatorio/ordens-servico/data")]
    public IActionResult GetOrdensServicoPorData([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
    {
        var ordensServico = _relatorioService.GetOrdensServicoPorData(dataInicio, dataFim);
        return Ok(ordensServico);
    }

    [HttpGet("relatorio/faturamento/data")]
    public IActionResult GetFaturamentoPorData([FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
    {
        var faturamento = _relatorioService.GetFaturamentePorData(dataInicio, dataFim);
        return Ok(faturamento);
    }

    [HttpGet("relatorio/equipamentos/cliente/{clienteId}")]
    public IActionResult GetEquipamentosPorCliente(int clienteId)
    {
        var equipamentos = _relatorioService.GetEquipamentosPorCliente(clienteId);
        return Ok(equipamentos);
    }

}
