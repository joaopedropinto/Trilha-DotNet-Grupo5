namespace Ordem_Servico.Application.InputModels;

public class NewEquipamentoInputModel
{
    public required string Tipo { get; set; }
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public required string DadosAdicionais { get; set; }
    public required string DefeitoDeclarado { get; set; }
    public required string Solucao { get; set; }
}
