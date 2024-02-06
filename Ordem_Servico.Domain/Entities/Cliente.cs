namespace Ordem_Servico.Domain;
public class Cliente
{
    public int ClienteID { get; set; }
    public string? CPF { get; set; }
    public string? CNPJ { get; set; }
    public string? Nome { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Endereco { get; set; }
    public ICollection<OrdemServico>? OrdemServico {get; set;}
    public int OrdemServicoID { get; set; }
}
