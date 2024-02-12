namespace Ordem_Servico.Domain.Entities;

public class Servico : BaseEntity
{
    public int ServicoID { get; set; }
    public DateTime Data { get; set; }
    public required string Descricao { get; set; }
    public double Valor { get; set; }
    public ICollection<OrdemServico>? OrdemServicos { get; set; }
}
