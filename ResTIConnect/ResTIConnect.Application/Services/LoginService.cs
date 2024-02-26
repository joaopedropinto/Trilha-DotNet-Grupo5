using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Context;
using ResTIConnect.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ResTIConnect.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ResTIConnectContext _dbcontext;

        public LoginService(ResTIConnectContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<UsuarioViewModel?> Authenticate(NewLoginInputModel login)
        {
            var _usuario = await _dbcontext.Usuarios
                .Include(u => u.Endereco)
                .Include(u => u.Perfis)
                .FirstOrDefaultAsync(u => u.Email == login.Email && u.Senha == login.Senha);

            if (_usuario == null)
            {
                return null;
            }

            return new UsuarioViewModel
            {
                UsuarioId = _usuario.UsuarioId,
                Nome = _usuario.Nome,
                Apelido = _usuario.Apelido,
                Email = _usuario.Email,
                Telefone = _usuario.Telefone,
                Endereco = new EnderecoViewModel
                {
                    EnderecoId = _usuario.Endereco?.EnderecoId ?? 0,
                    Logradouro = _usuario.Endereco?.Logradouro,
                    Numero = _usuario.Endereco?.Numero ?? 0,
                    Cidade = _usuario.Endereco?.Cidade,
                    Complemento = _usuario.Endereco?.Complemento,
                    Bairro = _usuario.Endereco?.Bairro,
                    Estado = _usuario.Endereco?.Estado,
                    Cep = _usuario.Endereco?.Cep,
                    Pais = _usuario.Endereco?.Pais,
                    UsuarioId = _usuario.Endereco?.UsuarioId
                },
                Perfis = _usuario.Perfis?.Select(p => new PerfilViewModel
                {
                    PerfilId = p.PerfilId,
                    Descricao = p.Descricao,
                    Permissoes = p.Permissoes,
                    UsuarioId = p.UsuarioId
                }).ToList()
            };
        }
    }
}
