namespace Ordem_Servico.Domain.Entities;
public class Tecnico : Pessoa
{
    public int TecnicoID { get; set; }
    public required string Especialidade { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }
    public ICollection<OrdemServico>? OrdemServicos { get; }
}
