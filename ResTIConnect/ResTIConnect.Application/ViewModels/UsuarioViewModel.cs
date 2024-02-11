namespace ResTIConnect.Application.ViewModels;

public class UsuarioViewModel
{
    public int UsuarioId { get; set; }
    public string? Nome { get; set; }
    public string? Apelido { get; set; }
    public string? Email { get; set;}
    public string? Senha { get;set;}
    public string? Telefone{get;set;}
    public EnderecoViewModel? Endereco { get; set; }
    public ICollection<PerfilViewModel>? Perfis { get; set; }
}
