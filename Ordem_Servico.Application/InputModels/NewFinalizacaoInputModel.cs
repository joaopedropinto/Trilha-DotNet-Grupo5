namespace Ordem_Servico.Application.InputModels;

public class NewFinalizacaoInputModel
{
    public DateTime DataFinalizacao { get; set; }
    public string? Comentario { get; set; }
    public int OrdemServicoID { get; set; }

}