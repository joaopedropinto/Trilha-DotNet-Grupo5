namespace TechMed.Application.ViewModels;

public class ExameViewModel
{
    public int ExameId { get; set; }
    public required string Nome { get; set; }
    public DateTime DataHora { get; set; }
    public double Valor { get; set; }
    public string Local { get; set; } = null!; 
    public string ResultadoDescricao { get; set; } = null!;
    public AtendimentoViewModel Atendimento { get; set; } = null!;
}
