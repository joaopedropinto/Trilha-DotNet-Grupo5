namespace ResTIConnect.Application.ViewModels;
public class SistemaViewModel
{
    public int Sistemald { get; set; }
    public string? Descricao { get; set; }
    public string? Tipo { get; set; }
    public string? EnderecoEntrada { get; set; }
    public string? EnderecoSaida { get; set; }
    public string? Protocolo { get; set; }
    public DateTimeOffset DataHoraInicioIntegracao { get; set; }
    public string? Status { get; set; }
    public virtual ICollection<UsuarioViewModel> Usuarios { get; set; } = new List<UsuarioViewModel>();
    public virtual ICollection<EventoViewModel> Eventos { get; set; } = new List<EventoViewModel>();
}
