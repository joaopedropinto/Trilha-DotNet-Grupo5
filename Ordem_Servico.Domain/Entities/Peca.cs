namespace Ordem_Servico.Domain;

public class Peca
{
    public int PecaID { get; set; }
    public string? Tipo { get; set; }
    public string? Descrição { get; set; } // Corrigido de Descrição para Descrição
    public double Valor { get; set; }
    public ICollection<OrdemServico>? OrdemServicos { get; }
}