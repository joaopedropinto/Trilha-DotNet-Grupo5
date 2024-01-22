namespace Ordem_Servico.Domain;

public class Peca
{
    public int PecaID { get; set; }
    public required string Tipo { get; set; }
    public string? Descrição { get; set; }
    public double Valor { get; set; }
    public ICollection<OrdemServico>? OrdemServicos { get; set; }
}
