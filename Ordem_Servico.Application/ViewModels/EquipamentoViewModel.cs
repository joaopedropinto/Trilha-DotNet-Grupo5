namespace Ordem_Servico.Application;

public class EquipamentoViewModel
{
    public int EquipamentoID { get; set; }
    public required string Tipo { get; set; }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public string? DadosAdicionais { get; set; }
    public required string DefeitoDeclarado { get; set; }
    public string? Solucao { get; set; }

}
