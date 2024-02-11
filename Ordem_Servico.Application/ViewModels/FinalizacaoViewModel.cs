namespace Ordem_Servico.Application.ViewModels;

public class FinalizacaoViewModel
{
    public int FinalizacaoID { get; set; }
    public DateTime DataFinalizacao { get; set; }
    public string? Comentario { get; set; }
    public int OrdemServicoID { get; set; }
}
