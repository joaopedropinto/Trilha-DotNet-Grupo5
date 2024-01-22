namespace Ordem_Servico.Domain;

public class Ocorrencia
{
    public int OcorrenciaID { get; set; }
    public required string Descricao { get; set; }
    public string? Situacao { get; set; }
    public DateTime DataHora { get; set; }
    public ICollection<OrdemServico>? OrdemServicos { get; set; }
}
