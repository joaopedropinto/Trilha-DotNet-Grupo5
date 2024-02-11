namespace Ordem_Servico.Domain.Entities;

public abstract class Pessoa : BaseEntity
{
    public required string Nome { get; set; }
}
