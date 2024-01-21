namespace Ordem_Servico.Domain;

public class OrdemServico
{
    public int OrdemServicoID { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime Prazo { get; set; }
    public string? FormaPagamento { get; set; }
    public string? Status { get; set; }
    public int ClienteID { get; set; }
    public int TecnicoID { get; set; }
    public Finalizacao? Finalizacao { get; set; }
    public Cliente? Cliente { get; set; }
    public Tecnico? Tecnico { get; set; }
}