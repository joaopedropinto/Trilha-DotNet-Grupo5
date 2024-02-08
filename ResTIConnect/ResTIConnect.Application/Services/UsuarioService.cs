using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Context;
using ResTIConnect.Domain.Exceptions;

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
            EnderecoId = usuario.EnderecoId
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
        var _usuarios = _dbcontext.Usuarios.ToList();
        return _usuarios.Select(c => new UsuarioViewModel()
        {
            UsuarioId = c.UsuarioId,
            Nome = c.Nome,
            Apelido = c.Apelido,
            Email = c.Email,
            Senha = c.Senha,
            Telefone = c.Telefone
        }).ToList();
    }
    public UsuarioViewModel? GetById(int id)
    {

        var _usuario = GetByDbId(id);

        return new UsuarioViewModel()
        {
            UsuarioId = _usuario.UsuarioId,
            Nome = _usuario.Nome,
            Apelido = _usuario.Apelido,
            Email = _usuario.Email,
            Senha = _usuario.Senha,
            Telefone = _usuario.Telefone
        };
    }

    public void Update(int id, NewUsuarioInputModel usuario)
    {
        var _usuario = GetByDbId(id);
        _usuario.Nome = usuario.Nome;
        _dbcontext.Usuarios.Update(_usuario);
        _dbcontext.SaveChanges();
    }
}
