namespace Ordem_Servico.Domain;

public class Peca : BaseEntity
{
    public int PecaID { get; set; }
    public string? Tipo { get; set; }
    public string? Descricao { get; set; } 
    public double Valor { get; set; }
    public ICollection<OrdemServico>? OrdemServicos { get; set; }
}