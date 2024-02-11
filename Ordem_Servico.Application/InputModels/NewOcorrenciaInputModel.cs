namespace Ordem_Servico.Application.InputModels;

public class NewOcorrenciaInputModel
{    
    public string Descricao { get; set; }
    public string? Situacao { get; set; }
    public DateTime DataHora { get; set; }
    public ICollection<int>? OrdemServicoIds { get; set; }
}
