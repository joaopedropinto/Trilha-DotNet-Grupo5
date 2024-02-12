using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.Application.Services.Interfaces;

public interface IRelatorioService
{
    public List<OrdemServicoViewModel> GetOrdensServicoPorStatus(string status);
    public List<OrdemServicoViewModel> GetOrdensServicoPorData(DateTime dataInicio, DateTime dataFim);
    public double GetFaturamentePorData(DateTime dataInicio, DateTime dataFim);
    public List<EquipamentoViewModel> GetEquipamentosPorCliente(int clienteId);
}
