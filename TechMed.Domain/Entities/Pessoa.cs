namespace TechMed.Domain.Entities;
public abstract class Pessoa : BaseEntity
{
    public required string Nome { get; set; }
    public required string CPF { get; set; }
}