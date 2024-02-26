using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Domain.Entities;
using Ordem_Servico.Infra.Auth;

namespace Ordem_Servico.Application.Services;

public class TecnicoService : ITecnicoService
{
    private readonly OrdemServicoContext _dbcontext;
    private readonly IAuthService _authService;

    public TecnicoService(OrdemServicoContext dbcontext, IAuthService authService)
    {
        _dbcontext = dbcontext;
        _authService = authService;
    }
    private Tecnico GetByDbId(int id)
    {
        var _tecnico = _dbcontext.Tecnico.Find(id);
        if (_tecnico is null)
            throw new Exception();

        return _tecnico;
    }
    public int Create(NewTecnicoInputModel tecnico)
    {
        tecnico.Senha = _authService.ComputeSha256Hash(tecnico.Senha);
        var _tecnico = new Tecnico
        {
            Nome = tecnico.Nome,
            Especialidade = tecnico.Especialidade,
            Telefone = tecnico.Telefone,
            Email = tecnico.Email,
            Senha = tecnico.Senha
        };
        _dbcontext.Tecnico.Add(_tecnico);

        _dbcontext.SaveChanges();

        return _tecnico.TecnicoID;
    }

    public void Delete(int id)
    {
        var _tecnico = GetByDbId(id);

        _dbcontext.Tecnico.Remove(_tecnico);

        _dbcontext.SaveChanges();
    }

    public List<TecnicoViewModel> GetAll()
    {
        var _tecnicos = _dbcontext.Tecnico.ToList();

        return _tecnicos.Select(tecnico => new TecnicoViewModel()
        {
            TecnicoID = tecnico.TecnicoID,
            Nome = tecnico.Nome,
            Especialidade = tecnico.Especialidade,
            Telefone = tecnico.Telefone,
            Email = tecnico.Email,
        }).ToList();
    }

    public TecnicoViewModel? GetById(int id)
    {
        var _tecnico = GetByDbId(id);

        return new TecnicoViewModel()
        {
            TecnicoID = _tecnico.TecnicoID,
            Nome = _tecnico.Nome,
            Especialidade = _tecnico.Especialidade,
            Telefone = _tecnico.Telefone,
            Email = _tecnico.Email,
        };
    }

    public void Update(int id, NewTecnicoInputModel tecnico)
    {
        var _tecnico = GetByDbId(id);

        _tecnico.Nome = tecnico.Nome;
        _tecnico.Especialidade = tecnico.Especialidade;
        _tecnico.Telefone = tecnico.Telefone;
        _tecnico.Email = tecnico.Email;

        _dbcontext.Tecnico.Update(_tecnico);

        _dbcontext.SaveChanges();
    }
}

