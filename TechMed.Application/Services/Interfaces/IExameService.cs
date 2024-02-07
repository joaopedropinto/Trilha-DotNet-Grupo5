using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.Interfaces;

public interface IExameService
{
   public List<ExameViewModel> GetAll();
   public ExameViewModel? GetById(int id);
   public ExameViewModel GetByAtendimentoId(int AtendimentoId);
   public int Create(NewExameInputModel exame);
}