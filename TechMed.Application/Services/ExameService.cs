using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence;
using TechMed.Core.Exceptions;

namespace TechMed.Application.Services;
public class ExameService : IExameService {
    private readonly TechMedDbContext _dbContext;

    public ExameService(TechMedDbContext dbContext) {
        _dbContext = dbContext;
    }

    public int Create(NewExameInputModel exame) {
        var _atendimento = _dbContext.Atendimentos.Find(exame.AtendimentoId);
        var newExame = new Exame(){
            Atendimento = _atendimento ?? throw new AtendimentoNotFoundException()
        };
        _dbContext.Exames.Add(newExame);
        _dbContext.SaveChanges();
        return newExame.ExameId;
    }

    public List<ExameViewModel> GetAll() {
        var exames = _dbContext.Exames.ToList();
        return exames.Select(d => new ExameViewModel(){
            ExameId = d.ExameId,
        }).ToList();
    }

    public ExameViewModel? GetById(int id) {
        var exame = _dbContext.Exames.Find(id);
        if(exame == null) return null;
        return new ExameViewModel(){
            ExameId = exame.ExameId,
        };
    }

    public List<ExameViewModel> GetByAtendimentoId(int AtendimentoId) {
        var exames = _dbContext.Exames.Where(d => d.AtendimentoId == AtendimentoId).ToList();
        return exames.Select(d => new ExameViewModel(){
            ExameId = d.ExameId,
        }).ToList();
    }

    public void Update(int id, NewExameInputModel exame) {
        var _exame = _dbContext.Exames.Find(id);
        if(_exame == null) throw new ExameNotFoundException();
        _dbContext.SaveChanges();
    }

    public void Delete(int id) {
        var _exame = _dbContext.Exames.Find(id);
        if(_exame == null) throw new ExameNotFoundException();
        _dbContext.Exames.Remove(_exame);
        _dbContext.SaveChanges();
    }
}