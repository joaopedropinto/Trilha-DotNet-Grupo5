namespace Ordem_Servico.Domain;

public class Finalizacao
{
    public int FinalizacaoID { get; set; }
    public DateTime DataFinalizacao { get; set; }
    public string? Comentario { get; set; }
    public OrdemServico? OrdemServico { get; }
}