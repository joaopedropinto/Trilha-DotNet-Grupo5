namespace TechMed.Domain.Entities;
public class Atendimento : BaseEntity
{
    public int AtendimentoId { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public string SuspeitaInicial { get; set; } = null!;
    public DateTime DataHoraFim { get; set; }
    public string Diagnostico { get; set; } = null!;
    public int MedicoId { get; set; }
    public required Medico Medico { get; set; }
    public int PacienteId { get; set; }
    public required Paciente Paciente {get; set;}
    public ICollection<Exame>? Exames { get; set; }
}