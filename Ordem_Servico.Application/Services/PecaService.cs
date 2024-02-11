using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Domain.Entities;

namespace Ordem_Servico.Application.Services;
public class PecaService : IPecaService
{
    private readonly OrdemServicoContext _dbContext;

    public PecaService(OrdemServicoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<PecaViewModel> GetAll()
    {
        return _dbContext.Peca
            .Select(p => new PecaViewModel
            {
                PecaID = p.PecaID,
                Tipo = p.Tipo,
                Descrição = p.Descrição,
                Valor = p.Valor,
                OrdemServicosID = p.OrdemServicos.Select(os => os.OrdemServicoID).ToList()
            })
            .ToList();
    }

    public PecaViewModel? GetById(int id)
    {
        var peca = _dbContext.Peca
            .Where(p => p.PecaID == id)
            .Select(p => new PecaViewModel
            {
                PecaID = p.PecaID,
                Tipo = p.Tipo,
                Descrição = p.Descrição,
                Valor = p.Valor,
                OrdemServicosID = p.OrdemServicos != null ? p.OrdemServicos.Select(os => os.OrdemServicoID).ToList() : null
            })
            .FirstOrDefault();

        return peca;
    }

    public int Create(NewPecaInputModel peca)
    {
        var pecaEntity = new Peca
        {
            Tipo = peca.Tipo,
            Descrição = peca.Descrição,
            Valor = peca.Valor,
            OrdemServicos = peca.OrdemServicosID != null ? _dbContext.OrdemServico.Where(os => peca.OrdemServicosID.Contains(os.OrdemServicoID)).ToList() : null
        };

        _dbContext.Peca.Add(pecaEntity);
        _dbContext.SaveChanges();

        return pecaEntity.PecaID;
    }

    public void Update(int id, NewPecaInputModel peca)
    {
        var pecaEntity = _dbContext.Peca.Find(id);

        if (pecaEntity is null)
            throw new Exception();

        pecaEntity.Tipo = peca.Tipo;
        pecaEntity.Descrição = peca.Descrição;
        pecaEntity.Valor = peca.Valor;
        pecaEntity.OrdemServicos = peca.OrdemServicosID != null ? _dbContext.OrdemServico.Where(os => peca.OrdemServicosID.Contains(os.OrdemServicoID)).ToList() : null;

        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var peca = _dbContext.Peca.Find(id);

        if (peca != null)
        {
            _dbContext.Peca.Remove(peca);
            _dbContext.SaveChanges();
        }
    }

}
