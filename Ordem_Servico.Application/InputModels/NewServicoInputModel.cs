namespace Ordem_Servico.Application;

public class NewServicoInputModel
{
    public DateTime Data { get; set; }
    public required string Descricao { get; set; }
    public double Valor { get; set; }
}
