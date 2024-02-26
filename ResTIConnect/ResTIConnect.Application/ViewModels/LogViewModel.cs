namespace ResTIConnect.Application.ViewModels;
public class LogViewModel
{
    public int LogId { get; set; }
    public string? Tipo { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataHoraEvento { get; set; }
    public string? Entidade { get; set; }
    public string? TuplaId { get; set; }
    public string? Endereco { get; set; }
}
