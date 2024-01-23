namespace ResTIConnect.Domain;

public class Perfil
{
    public int PerfilId { get; set; }
    public string Descricao { get; set; }
    public string Permissoes { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
}