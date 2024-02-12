using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Domain.Entities;

namespace Ordem_Servico.Application.Services;

public class ServicoService : IServicoService
{
    private readonly OrdemServicoContext _dbcontext;
    public ServicoService(OrdemServicoContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    private Servico GetByDbId(int id)
    {
        var _servico = _dbcontext.Servico.Find(id);
        if (_servico is null)
            throw new Exception();

        return _servico;
    }
    public int Create(NewServicoInputModel servico)
    {
        var _servico = new Servico
        {
            Data = servico.Data,
            Descricao = servico.Descricao,
            Valor = servico.Valor
        };
        _dbcontext.Servico.Add(_servico);

        _dbcontext.SaveChanges();

        return _servico.ServicoID;
    }

    public void Delete(int id)
    {
        var _servico = GetByDbId(id);

        _dbcontext.Servico.Remove(_servico);

        _dbcontext.SaveChanges();
    }

    public List<ServicoViewModel> GetAll()
    {
        var _servicos = _dbcontext.Servico.ToList();

        return _servicos.Select(servico => new ServicoViewModel()
        {
            Data = servico.Data,
            Descricao = servico.Descricao,
            Valor = servico.Valor
        }).ToList();
    }

    public ServicoViewModel? GetById(int id)
    {
        var _servico = GetByDbId(id);

        return new ServicoViewModel()
        {
            Data = _servico.Data,
            Descricao = _servico.Descricao,
            Valor = _servico.Valor
        };
    }

    public void Update(int id, NewServicoInputModel servico)
    {
        var _servico = GetByDbId(id);

        _servico.Data = servico.Data;
        _servico.Descricao = servico.Descricao;
        _servico.Valor = servico.Valor;

        _dbcontext.Servico.Update(_servico);

        _dbcontext.SaveChanges();
    }
}
