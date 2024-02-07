﻿namespace ResTIConnect.Domain.Entities;

public class Usuario
{
    public int UsuarioId { get; set; }
    public required string Nome { get; set; }
    public string? Apelido { get; set; }
    public required string Email { get; set;}
    public required string Senha { get;set;}
    public string? Telefone{get;set;}
    public int EnderecoId { get; set; }
    public Endereco? Endereco { get; set; }
    public ICollection<Perfil>? Perfis { get; set; }
    public virtual ICollection<Sistema> Sistemas { get; set; } = new List<Sistema>();
}
