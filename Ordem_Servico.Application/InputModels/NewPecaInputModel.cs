namespace Ordem_Servico.Application.InputModels;

public class NewPecaInputModel
{
    public string? Tipo { get; set; }
    public string? Descrição { get; set; }
    public double Valor { get; set; }
    public ICollection<int>? OrdemServicosID { get; set; }
}