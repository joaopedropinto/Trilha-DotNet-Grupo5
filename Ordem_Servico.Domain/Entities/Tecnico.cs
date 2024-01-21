namespace Ordem_Servico.Domain;
public class Tecnico
{
    public int TecnicoID { get; set; }
    public string Nome { get; set; }
    public string Especialidade { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public ICollection<OrdemServico>? OrdemServico {get; set;}
    public int OrdemServicoID { get; set; }
}
