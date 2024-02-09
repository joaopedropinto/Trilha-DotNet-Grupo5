namespace ResTIConnect.Application.ViewModels;

public class UsuarioViewModel
{
    public int UsuarioId { get; set; }
    public required string Nome { get; set; }
    public string? Apelido { get; set; }
    public required string Email { get; set;}
    public required string Senha { get;set;}
    public string? Telefone{get;set;}
    public EnderecoViewModel? Endereco { get; set; }
    public ICollection<PerfilViewModel>? Perfis { get; set; }
    public virtual ICollection<SistemaViewModel> Sistemas { get; set; } = new List<SistemaViewModel>();
}
