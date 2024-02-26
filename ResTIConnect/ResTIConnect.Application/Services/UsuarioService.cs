using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Context;
using ResTIConnect.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ResTIConnect.Application.Services;
public class UsuarioService : IUsuarioService
{
    private readonly ResTIConnectContext _dbcontext;
    public UsuarioService(ResTIConnectContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    private Usuario GetByDbId(int id)
    {
        var _usuario = _dbcontext.Usuarios.Find(id);
        if (_usuario is null)
        {
            throw new UsuarioAlreadyExistsException();//fazer as exceptions pra adicionar aqui
        }
        return _usuario;
    }

    public int Create(NewUsuarioInputModel usuario)
    {
        var _usuario = new Usuario
        {
            Nome = usuario.Nome,
            Apelido = usuario.Apelido,
            Email = usuario.Email,
            Senha = usuario.Senha,
            Telefone = usuario.Telefone,
        };
        _dbcontext.Usuarios.Add(_usuario);
        _dbcontext.SaveChanges();
        return _usuario.UsuarioId;
    }

    public void Delete(int id)
    {
        var _usuario = GetByDbId(id);
        _dbcontext.Usuarios.Remove(_usuario);
        _dbcontext.SaveChanges();
    }

    public List<UsuarioViewModel> GetAll()
    {
        var _usuarios = _dbcontext.Usuarios
            .Include(u => u.Endereco)
            .Include(u => u.Perfis)
            .ToList();

        return _usuarios.Select(c => new UsuarioViewModel()
        {
            UsuarioId = c.UsuarioId,
            Nome = c.Nome,
            Apelido = c.Apelido,
            Email = c.Email,
            Senha = c.Senha,
            Telefone = c.Telefone,
            Endereco = new EnderecoViewModel
            {
                EnderecoId = c.Endereco?.EnderecoId ?? 0,
                Logradouro = c.Endereco?.Logradouro,
                Numero = c.Endereco?.Numero ?? 0,
                Cidade = c.Endereco?.Cidade,
                Complemento = c.Endereco?.Complemento,
                Bairro = c.Endereco?.Bairro,
                Estado = c.Endereco?.Estado,
                Cep = c.Endereco?.Cep,
                Pais = c.Endereco?.Pais,
                UsuarioId = c.Endereco?.UsuarioId
            },
            Perfis = c.Perfis?.Select(p => new PerfilViewModel
            {
                PerfilId = p.PerfilId,
                Descricao = p.Descricao,
                Permissoes = p.Permissoes,
                UsuarioId = p.UsuarioId
            }).ToList()
        }).ToList();
    }
    public UsuarioViewModel? GetById(int id)
    {
        var _usuario = GetByDbId(id);

        if (_usuario == null)
        {
            return null;
        }

        _usuario = _dbcontext.Usuarios
            .Include(u => u.Endereco)
            .Include(u => u.Perfis)
            .FirstOrDefault(u => u.UsuarioId == id);

        if (_usuario == null)
        {
            return null;
        }

        return new UsuarioViewModel()
        {
            UsuarioId = _usuario.UsuarioId,
            Nome = _usuario.Nome,
            Apelido = _usuario.Apelido,
            Email = _usuario.Email,
            Senha = _usuario.Senha,
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

    public List<UsuarioViewModel> GetUsersByUF(string uf)
    {
        var usersWithAddressInUF = _dbcontext.Usuarios
            .Include(u => u.Endereco)
            .Where(u => u.Endereco != null && u.Endereco.Estado == uf)
            .ToList();

        return usersWithAddressInUF.Select(u => new UsuarioViewModel
        {
            UsuarioId = u.UsuarioId,
            Nome = u.Nome,
            Apelido = u.Apelido,
            Email = u.Email,
            Senha = u.Senha,
            Telefone = u.Telefone,
            Endereco = new EnderecoViewModel
            {
                EnderecoId = u.Endereco?.EnderecoId ?? 0,
                Logradouro = u.Endereco?.Logradouro,
                Numero = u.Endereco?.Numero ?? 0,
                Cidade = u.Endereco?.Cidade,
                Complemento = u.Endereco?.Complemento,
                Bairro = u.Endereco?.Bairro,
                Estado = u.Endereco?.Estado,
                Cep = u.Endereco?.Cep,
                Pais = u.Endereco?.Pais
            },
            Perfis = u.Perfis?.Select(p => new PerfilViewModel
            {
                PerfilId = p.PerfilId,
                Descricao = p.Descricao,
                Permissoes = p.Permissoes,
                UsuarioId = p.UsuarioId
            }).ToList()
        }).ToList();
    }

    public void Update(int id, NewUsuarioInputModel usuario)
    {
        var _usuario = GetByDbId(id);
        _usuario.Nome = usuario.Nome;
        _dbcontext.Usuarios.Update(_usuario);
        _dbcontext.SaveChanges();
    }

    public async Task<PerfilViewModel?> GetProfileById(int id)
    {
        var perfil = await _dbcontext.Perfis
            .Include(p => p.Usuario)
            .FirstOrDefaultAsync(p => p.PerfilId == id);

        if (perfil == null)
        {
            return null;
        }

        return new PerfilViewModel()
        {
            PerfilId = perfil.PerfilId,
            Descricao = perfil.Descricao,
            Permissoes = perfil.Permissoes,
            UsuarioId = perfil.UsuarioId
        };
    }
}
