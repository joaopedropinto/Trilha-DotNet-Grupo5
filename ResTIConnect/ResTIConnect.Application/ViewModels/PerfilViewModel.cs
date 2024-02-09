namespace ResTIConnect.Application.ViewModels;
public class PerfilViewModel
{
    public int PerfilId { get; set; }
    public string? Descricao { get; set; }
    public string? Permissoes { get; set; }
    public UsuarioViewModel? Usuario { get; set; }
}
