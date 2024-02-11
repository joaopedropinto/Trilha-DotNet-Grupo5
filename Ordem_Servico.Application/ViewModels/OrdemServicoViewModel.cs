using Ordem_Servico.Domain;

namespace Ordem_Servico.Application.ViewModels;

public class OrdemServicoViewModel
{
    public int OrdemServicoID { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime Prazo { get; set; }
    public string? FormaPagamento { get; set; }
    public required string? Status { get; set; }
    public int ClienteID { get; set; }
    public int TecnicoID { get; set; }
    public required FinalizacaoViewModel? Finalizacao { get; set; }
    public required ICollection<int>? EquipamentosIDs { get; set; }
    public required ICollection<int>? ServicosIDs { get; set; }
    public required ICollection<int>? OcorrenciasIDs { get; set; }
    public required ICollection<int>? PecasIDs { get; set; }
}
