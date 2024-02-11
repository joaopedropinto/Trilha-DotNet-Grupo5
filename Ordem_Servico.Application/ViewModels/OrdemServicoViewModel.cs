using Ordem_Servico.Domain;

namespace Ordem_Servico.Application.ViewModels;

public class OrdemServicoViewModel
{
    public int OrdemServicoID { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime Prazo { get; set; }
    public required string? FormaPagamento { get; set; }
    public required string? Status { get; set; }
    public int ClienteID { get; set; }
    public int TecnicoID { get; set; }
    public required Finalizacao? Finalizacao { get; set; }
    public required ICollection<int>? Equipamentos { get; set; }
    public required ICollection<int>? Servicos { get; set; }
    // public required ICollection<Ocorrencia> Ocorrencias { get; set; }
    // public required ICollection<Peca> Pecas { get; set; }
}
