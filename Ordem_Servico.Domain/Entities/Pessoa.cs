namespace Ordem_Servico.Domain;

public abstract class Pessoa : BaseEntity
{
    public required string Nome { get; set; }
}
