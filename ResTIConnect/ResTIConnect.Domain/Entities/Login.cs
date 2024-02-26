using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Domain.Entitie;
public class Login
{
    public int LoginId { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
}

