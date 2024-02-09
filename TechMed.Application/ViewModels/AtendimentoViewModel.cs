namespace TechMed.Application.ViewModels;

public class AtendimentoViewModel
{
    public int AtendimentoId { get; set; }
    public DateTime DataHora { get; set; }
    public string SuspeitaInicial { get; set; } = null!; 
    public DateTime DataHoraFim { get; set; }
    public string Diagnostico { get; set; } = null!; 
    public PacienteViewModel Paciente { get; set; } = null!;
    public MedicoViewModel Medico { get; set; } = null!;
}
