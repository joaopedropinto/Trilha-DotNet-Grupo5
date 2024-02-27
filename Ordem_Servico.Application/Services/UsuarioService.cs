using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Domain.Entities;

namespace Ordem_Servico.Application.Services;
public class UsuarioService : IUsuarioService
{
    private readonly OrdemServicoContext _dbContext;

    public UsuarioService(OrdemServicoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<UsuarioViewModel> GetAll()
    {
        return _dbContext.Usuario
            .Select(u => new UsuarioViewModel
            {
                UsuarioID = u.UsuarioID,
                Nome = u.Nome,
                Email = u.Email
            })
            .ToList();
    }

    public UsuarioViewModel? GetById(int id)
    {
        var usuario = _dbContext.Usuario
            .Where(u => u.UsuarioID == id)
            .Select(u => new UsuarioViewModel
            {
                UsuarioID = u.UsuarioID,
                Nome = u.Nome,
                Email = u.Email
            })
            .FirstOrDefault();

        return usuario;
    }

    public int Create(NewUsuarioInputModel usuario)
    {
        var usuarioEntity = new Usuario
        {
            Nome = usuario.Nome,
            Email = usuario.Email
        };

        _dbContext.Usuario.Add(usuarioEntity);
        _dbContext.SaveChanges();

        return usuarioEntity.UsuarioID;
    }

    public void Update(int id, NewUsuarioInputModel usuario)
    {
        var usuarioEntity = _dbContext.Usuario.Find(id);

        if (usuarioEntity is null)
            throw new Exception();

        usuarioEntity.Nome = usuario.Nome;
        usuarioEntity.Email = usuario.Email;

        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var usuario = _dbContext.Usuario.Find(id);

        if (usuario != null)
        {
            _dbContext.Usuario.Remove(usuario);
            _dbContext.SaveChanges();
        }
    }
}

