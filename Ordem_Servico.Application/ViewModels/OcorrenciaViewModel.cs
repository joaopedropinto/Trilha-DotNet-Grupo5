namespace Ordem_Servico.Application.ViewModels;

public class OcorrenciaViewModel
{
    public int OcorrenciaID { get; set; }
    public string Descricao { get; set; }
    public string? Situacao { get; set; }
    public DateTime DataHora { get; set; }
    public ICollection<int>? OrdemServicoIds { get; set; }
}
