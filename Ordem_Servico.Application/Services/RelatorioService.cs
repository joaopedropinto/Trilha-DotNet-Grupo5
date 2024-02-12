using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.Application.Services;

public class RelatorioService : IRelatorioService
{
    private readonly OrdemServicoContext _dbcontext;
    public RelatorioService(OrdemServicoContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public List<OrdemServicoViewModel> GetOrdensServicoPorStatus(string status)
    {
        var ordensServico = _dbcontext.OrdemServico
            .Where(os => os.Status == status)
            .Select(os => new OrdemServicoViewModel
            {
                OrdemServicoID = os.OrdemServicoID,
                DataAbertura = os.DataAbertura,
                Prazo = os.Prazo,
                FormaPagamento = os.FormaPagamento,
                Status = os.Status,
                ClienteID = os.ClienteID,
                TecnicoID = os.TecnicoID,
                Finalizacao = os.Finalizacao != null ? new FinalizacaoViewModel
                {
                    FinalizacaoID = os.Finalizacao.FinalizacaoID,
                    DataFinalizacao = os.Finalizacao.DataFinalizacao,
                    Comentario = os.Finalizacao.Comentario
                } : null,
                EquipamentosIDs = os.Equipamentos != null ? os.Equipamentos.Select(e => e.EquipamentoID).ToList() : null,
                ServicosIDs = os.Servicos != null ? os.Servicos.Select(s => s.ServicoID).ToList() : null,
                OcorrenciasIDs = os.Ocorrencias != null ? os.Ocorrencias.Select(o => o.OcorrenciaID).ToList() : null,
                PecasIDs = os.Pecas != null ? os.Pecas.Select(p => p.PecaID).ToList() : null
            })
            .ToList();

        return ordensServico;
    }

    public List<OrdemServicoViewModel> GetOrdensServicoPorData(DateTime dataInicio, DateTime dataFim)
    {
        var ordensServico = _dbcontext.OrdemServico
            .Where(os => os.DataAbertura >= dataInicio && os.DataAbertura <= dataFim)
            .Select(os => new OrdemServicoViewModel
            {
                OrdemServicoID = os.OrdemServicoID,
                DataAbertura = os.DataAbertura,
                Prazo = os.Prazo,
                FormaPagamento = os.FormaPagamento,
                Status = os.Status,
                ClienteID = os.ClienteID,
                TecnicoID = os.TecnicoID,
                Finalizacao = os.Finalizacao != null ? new FinalizacaoViewModel
                {
                    FinalizacaoID = os.Finalizacao.FinalizacaoID,
                    DataFinalizacao = os.Finalizacao.DataFinalizacao,
                    Comentario = os.Finalizacao.Comentario
                } : null,
                EquipamentosIDs = os.Equipamentos != null ? os.Equipamentos.Select(e => e.EquipamentoID).ToList() : null,
                ServicosIDs = os.Servicos != null ? os.Servicos.Select(s => s.ServicoID).ToList() : null,
                OcorrenciasIDs = os.Ocorrencias != null ? os.Ocorrencias.Select(o => o.OcorrenciaID).ToList() : null,
                PecasIDs = os.Pecas != null ? os.Pecas.Select(p => p.PecaID).ToList() : null
            })
            .ToList();

        return ordensServico;
        
    }

    public double GetFaturamentePorData(DateTime dataInicio, DateTime dataFim)
    {
        var faturamento = _dbcontext.OrdemServico
            .Where(os => os.DataAbertura >= dataInicio && os.DataAbertura <= dataFim)
            .SelectMany(os => os.Pecas)
            .Sum(p => p.Valor) + _dbcontext.OrdemServico
            .Where(os => os.DataAbertura >= dataInicio && os.DataAbertura <= dataFim)
            .SelectMany(os => os.Servicos)
            .Sum(s => s.Valor);

        return faturamento;
    }

    public List<EquipamentoViewModel> GetEquipamentosPorCliente(int clienteId)
    {
        var equipamentos = _dbcontext.OrdemServico
            .Where(os => os.ClienteID == clienteId)
            .SelectMany(os => os.Equipamentos)
            .Select(e => new EquipamentoViewModel
            {
                EquipamentoID = e.EquipamentoID,
                Tipo = e.Tipo,
                Marca = e.Marca,
                Modelo = e.Modelo,
                DadosAdicionais = e.DadosAdicionais,
                DefeitoDeclarado = e.DefeitoDeclarado,
                Solucao = e.Solucao,
            })
            .ToList();

        return equipamentos;
       
    }

}
