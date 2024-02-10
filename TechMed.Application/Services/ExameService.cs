using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;
using TechMed.Domain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application.Services
{
    public class ExameService : IExameService
    {
        private readonly TechMedDbContext _dbContext;

        public ExameService(TechMedDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ExameViewModel> GetAll()
        {
            var exames = _dbContext.Exames.ToList();
            return exames.Select(e => new ExameViewModel
            {
                ExameId = e.ExameId,
                Nome = e.Nome
            }).ToList();
        }

        public ExameViewModel? GetById(int id)
        {
            var exame = _dbContext.Exames.Find(id);
            if (exame == null) return null;
            return new ExameViewModel
            {
                ExameId = exame.ExameId,
                Nome = exame.Nome
            };
        }

        public ExameViewModel GetByAtendimentoId(int AtendimentoId)
        {
            var exame = _dbContext.Exames
                .Where(e => e.AtendimentoId == AtendimentoId)
                .Select(e => new ExameViewModel
                {
                    ExameId = e.ExameId,
                    Nome = e.Nome,
                    DataHora = e.DataHora,
                    Valor = e.Valor,
                    Local = e.Local,
                    ResultadoDescricao = e.ResultadoDescricao,
                    Atendimento = new AtendimentoViewModel
                    {
                        
                    }
                })
                .FirstOrDefault();

            return exame;
        }


        public int Create(NewExameInputModel exame)
        {
            var newExame = new Exame
            {
                Nome = exame.Nome,
                DataHora = exame.DataHora,
                Valor = exame.Valor,
                Local = exame.Local,
                ResultadoDescricao = exame.ResultadoDescricao,
                AtendimentoId = exame.AtendimentoId
            };
            _dbContext.Exames.Add(newExame);
            _dbContext.SaveChanges();
            return newExame.ExameId;
        }

        public void Update(int id, NewExameInputModel exame)
        {
            var exameToUpdate = _dbContext.Exames.Find(id);
            if (exameToUpdate == null) throw new ExameNotFoundException();

            exameToUpdate.Nome = exame.Nome;
            exameToUpdate.DataHora = exame.DataHora;
            exameToUpdate.Valor = exame.Valor;
            exameToUpdate.Local = exame.Local;
            exameToUpdate.ResultadoDescricao = exame.ResultadoDescricao;
            exameToUpdate.AtendimentoId = exame.AtendimentoId;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var exameToDelete = _dbContext.Exames.Find(id);
            if (exameToDelete == null) throw new ExameNotFoundException();

            _dbContext.Exames.Remove(exameToDelete);
            _dbContext.SaveChanges();
        }
    }
}
