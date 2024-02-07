namespace TechMed.Application.InputModels;

public class NewAtendimentoInputModel
{
    public DateTime DataHora { get; set; }
    public string SuspeitaInicial { get; set; } = null!; 
    public DateTime DataHoraFim { get; set; }
    public string Diagnostico { get; set; } = null!; 
    public int PacienteId { get; set; }
    public int MedicoId { get; set; }
}
