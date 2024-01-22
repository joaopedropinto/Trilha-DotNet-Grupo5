namespace Ordem_Servico.Domain;

public class Equipamento
{
    public int EquipamentoID { get; set; }
    public required string Tipo { get; set; }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public string? DadosAdicionais { get; set; }
    public required string DefeitoDeclarado { get; set; }
    public string? Solucao { get; set; }
    public ICollection<OrdemServico>? OrdemServicos { get; set; }
}
