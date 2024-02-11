namespace Ordem_Servico.Application.ViewModels;

public class PecaViewModel
{
    public int PecaID { get; set; }
    public string? Tipo { get; set; }
    public string? Descricao { get; set; }
    public double Valor { get; set; }
    public ICollection<int>? OrdemServicosID { get; set; }
}
