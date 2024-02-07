namespace TechMed.Application.InputModels;

public class NewExameInputModel
{
    public required string Nome { get; set; }
    public DateTime DataHora { get; set; }
    public double Valor { get; set; }
    public string Local { get; set; } = null!; 
    public string ResultadoDescricao { get; set; } = null!; 
    public int AtendimentoId { get; set; }
}
