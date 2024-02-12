using Microsoft.EntityFrameworkCore;
using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Domain;

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
        var _servico = _dbcontext.Servico.Include(s => s.OrdemServicos)
                                        .FirstOrDefault(s => s.ServicoID == id);
        if (_servico is null)
            throw new Exception("Serviço não encontrado");

        return _servico;
    }
    public int Create(NewServicoInputModel servico)
    {
        var _servico = new Servico
        {
            Data = servico.Data,
            Descricao = servico.Descricao,
            Valor = servico.Valor,
            OrdemServicos = servico.OrdemServicosID != null ? _dbcontext.OrdemServico
                                                                .Where(os => servico.OrdemServicosID
                                                                .Contains(os.OrdemServicoID))
                                                                .ToList() : null
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
        return _dbcontext.Servico.Select(s => new ServicoViewModel
        {
            ServicoID = s.ServicoID,
            Data = s.Data,
            Descricao = s.Descricao,
            Valor = s.Valor,
            OrdemServicosID = s.OrdemServicos != null ? s.OrdemServicos
                                                        .Select(os => os.OrdemServicoID)
                                                        .ToList() : null
        }).ToList();
    }

    public ServicoViewModel? GetById(int id)
    {
        var _servico = GetByDbId(id);

        return new ServicoViewModel()
        {
            ServicoID = _servico.ServicoID,
            Data = _servico.Data,
            Descricao = _servico.Descricao,
            Valor = _servico.Valor,
            OrdemServicosID = _servico.OrdemServicos?
                                .Select(os => os.OrdemServicoID)
                                .ToList()
        };
    }

    public void Update(int id, NewServicoInputModel servico)
    {
        var _servico = GetByDbId(id);

        _servico.Data = servico.Data;
        _servico.Descricao = servico.Descricao;
        _servico.Valor = servico.Valor;
        _servico.OrdemServicos = servico.OrdemServicosID != null ? _dbcontext.OrdemServico
                                                            .Where(os => servico.OrdemServicosID
                                                            .Contains(os.OrdemServicoID))
                                                            .ToList() : null;

        _dbcontext.Servico.Update(_servico);

        _dbcontext.SaveChanges();
    }
}
