namespace TechMed.Application.InputModels;

public class NewMedicoInputModel
{
    public string Nome { get; set; } = null!; 
    public required string CRM { get; set;}
    public required string CPF { get; set; }
}
