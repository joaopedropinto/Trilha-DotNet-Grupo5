namespace ResTIConnect.Application.InputModels;
public class NewUsuarioInputModel
{
    public required string Nome { get; set; }
    public string? Apelido { get; set; }
    public required string Email { get; set; }
    public required string Senha { get; set; }
    public string? Telefone { get; set; }
}
