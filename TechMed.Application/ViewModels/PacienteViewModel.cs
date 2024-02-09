namespace TechMed.Application.ViewModels;

public class PacienteViewModel
{
    public int PacienteId { get; set; }
    public required string? Nome { get; set; }
    public required string CPF { get; set; }
    public DateTime DataNascimento { get; set; }

}
