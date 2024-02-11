﻿namespace Ordem_Servico.Application.InputModels;

public class NewClienteInputModel
{
    public required string CPF { get; set; }
    public required string CNPJ { get; set; }
    public required string Nome { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }
    public required string Endereco { get; set; }
}
