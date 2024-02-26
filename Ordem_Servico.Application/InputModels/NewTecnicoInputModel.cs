namespace Ordem_Servico.Application.InputModels;

public class NewTecnicoInputModel
{
    public required string Nome { get; set; }
    public required string Especialidade { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }
    public required string Senha { get; set; }

}
