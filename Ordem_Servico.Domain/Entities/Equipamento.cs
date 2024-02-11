namespace Ordem_Servico.Domain.Entities;

public class Equipamento : BaseEntity
{
    public int EquipamentoID { get; set; }
    public required string Tipo { get; set; }
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public required string DadosAdicionais { get; set; }
    public required string DefeitoDeclarado { get; set; }
    public string? Solucao { get; set; }
    public ICollection<OrdemServico>? OrdemServicos { get; }
}
