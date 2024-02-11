using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Domain.Entities;

namespace Ordem_Servico.Application.Services;

public class FinalizacaoService : IFinalizacaoService
{
    private readonly OrdemServicoContext _dbContext;

    public FinalizacaoService(OrdemServicoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<FinalizacaoViewModel> GetAll()
    {
        return _dbContext.Finalizacao
            .Select(f => new FinalizacaoViewModel
            {
                FinalizacaoID = f.FinalizacaoID,
                DataFinalizacao = f.DataFinalizacao,
                Comentario = f.Comentario,
                OrdemServicoID = f.OrdemServico.OrdemServicoID 
            })
            .ToList();
    }

    public FinalizacaoViewModel? GetById(int id)
    {
        var finalizacao = _dbContext.Finalizacao
            .Where(f => f.FinalizacaoID == id)
            .Select(f => new FinalizacaoViewModel
            {
                FinalizacaoID = f.FinalizacaoID,
                DataFinalizacao = f.DataFinalizacao,
                Comentario = f.Comentario,
                OrdemServicoID = f.OrdemServico.OrdemServicoID 
            })
            .FirstOrDefault();

        return finalizacao;
    }

    public int Create(NewFinalizacaoInputModel finalizacao)
    {
        var finalizacaoEntity = new Finalizacao
        {
            DataFinalizacao = finalizacao.DataFinalizacao,
            Comentario = finalizacao.Comentario,
            OrdemServico = _dbContext.OrdemServico.Find(finalizacao.OrdemServicoID)
        };

        _dbContext.Finalizacao.Add(finalizacaoEntity);
        _dbContext.SaveChanges();

        return finalizacaoEntity.FinalizacaoID;
    }

    public void Update(int id, NewFinalizacaoInputModel finalizacao)
    {
        var finalizacaoEntity = _dbContext.Finalizacao.Find(id);

        if (finalizacaoEntity is null)
            throw new Exception();

        finalizacaoEntity.DataFinalizacao = finalizacao.DataFinalizacao;
        finalizacaoEntity.Comentario = finalizacao.Comentario;
        finalizacaoEntity.OrdemServico = _dbContext.OrdemServico.Find(finalizacao.OrdemServicoID);

        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var finalizacao = _dbContext.Finalizacao.Find(id);

        if (finalizacao is null)
            throw new Exception();

        _dbContext.Finalizacao.Remove(finalizacao);
        _dbContext.SaveChanges();
    }

}
