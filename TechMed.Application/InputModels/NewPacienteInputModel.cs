namespace TechMed.Application.InputModels;

public class NewPacienteInputModel
{
    public required string Nome { get; set; } = null!; 
    public required string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
}
