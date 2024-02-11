namespace Ordem_Servico.Domain.Entities
{
    public class Cliente : Pessoa
    {
        public int ClienteID { get; set; }
        public string? CPF { get; set; }
        public string? CNPJ { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Endereco { get; set; }
        public ICollection<OrdemServico>? OrdemServicos { get; }
    }
}