namespace Ordem_Servico.Application.ViewModels;

public class ServicoViewModel
{
    public int ServicoID { get; set; }
    public DateTime Data { get; set; }
    public required string Descricao { get; set; }
    public double Valor { get; set; }
}
