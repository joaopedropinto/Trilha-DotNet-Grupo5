namespace TechMed.Application.ViewModels;

public class MedicoViewModel
{
    public int MedicoId { get; set; }
    public string? Nome { get; set; }
    public required string CRM { get; set;}
    public required string CPF { get; set; }
}
