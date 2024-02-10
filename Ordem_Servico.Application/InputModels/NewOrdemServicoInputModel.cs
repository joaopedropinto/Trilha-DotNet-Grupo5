using Ordem_Servico.Domain;

namespace Ordem_Servico.Application;

public class NewOrdemServicoInputModel
{
    public DateTime DataAbertura { get; set; }
    public DateTime Prazo { get; set; }
    public required string FormaPagamento { get; set; }
    public required string Status { get; set; }
    public int ClienteID { get; set; }
    public int TecnicoID { get; set; }
    public required Finalizacao Finalizacao { get; set; }
    public required ICollection<Ocorrencia> Ocorrencias { get; set; }
    public required ICollection<int> EquipamentosIDs { get; set; }
    public required ICollection<int> ServicosIDs { get; set; }
    public required ICollection<Peca> Pecas { get; set; }
}
