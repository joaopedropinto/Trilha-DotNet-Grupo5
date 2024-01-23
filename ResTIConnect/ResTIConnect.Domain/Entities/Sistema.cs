namespace ResTIConnect.Domain;

public class Sistema
{
    public int Sistemald { get; set; }
    public string? Descricao { get; set; }
    public string? Tipo { get; set; }
    public string? EnderecoEntrada { get; set; }
    public string? EnderecoSaida { get; set; }
    public string? Protocolo { get; set; }
    public DateTimeOffset DataHoraInicioIntegracao { get; set; }
    public string? Status { get; set; }
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
