namespace Ordem_Servico.Application.InputModels;

public class NewOrdemServicoInputModel
{
    public DateTime DataAbertura { get; set; }
    public DateTime Prazo { get; set; }
    public string? FormaPagamento { get; set; }
    public required string Status { get; set; }
    public int ClienteID { get; set; }
    public int TecnicoID { get; set; }
    public int FinalizacaoID { get; set; }
    public required ICollection<int> EquipamentosIDs { get; set; }
}
