using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Context;
//using ResTIConnect.Domain.Exceptions;

namespace ResTIConnect.Application.Services;
public class PerfilService : IPerfilService
{
    private readonly ResTIConnectContext _dbcontext;
    public PerfilService(ResTIConnectContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    private Perfil GetByDbId(int id)
    {
        var _perfil = _dbcontext.Perfis.Find(id);
        if (_perfil is null)
        {
            throw new Exception();//fazer as exceptions pra adicionar aqui
        }
        return _perfil;
    }

    public int Create(NewPerfilInputModel perfil)
    {
        var _perfil = new Perfil
        {
            Descricao = perfil.Descricao,
            Permissoes = perfil.Permissoes
        };
        _dbcontext.Perfis.Add(_perfil);
        _dbcontext.SaveChanges();
        return _perfil.PerfilId;
    }

    public void Delete(int id)
    {
        var _perfil = GetByDbId(id);
        _dbcontext.Perfis.Remove(_perfil);
        _dbcontext.SaveChanges();
    }

    public List<PerfilViewModel> GetAll()
    {
        var _perfils = _dbcontext.Perfis.ToList();
        return _perfils.Select(c => new PerfilViewModel()
        {
            PerfilId = c.PerfilId,
            Descricao = c.Descricao,
            Permissoes = c.Permissoes
        }).ToList();
    }
    public PerfilViewModel? GetById(int id)
    {

        var _perfil = GetByDbId(id);

        return new PerfilViewModel()
        {
            PerfilId = _perfil.PerfilId,
            Descricao = _perfil.Descricao,
            Permissoes = _perfil.Permissoes
        };
    }

    public void Update(int id, NewPerfilInputModel perfil)
    {
        var _perfil = GetByDbId(id);
        _perfil.Descricao = perfil.Descricao;
        _dbcontext.Perfis.Update(_perfil);
        _dbcontext.SaveChanges();
    }
}
