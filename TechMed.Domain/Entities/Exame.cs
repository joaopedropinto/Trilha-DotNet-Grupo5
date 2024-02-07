namespace TechMed.Domain.Entities;
public class Exame : BaseEntity
{
   public int ExameId { get; set; }
   public string Nome { get; set; } = null!;
   public DateTime DataHora { get; set; }
   public double Valor { get; set; }
   public string Local { get; set; } = null!;
   public string ResultadoDescricao { get; set; } = null!;
   public int AtendimentoId { get; set; }
   public Atendimento Atendimento { get; set; } = null!;
}