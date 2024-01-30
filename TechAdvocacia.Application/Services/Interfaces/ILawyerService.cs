namespace TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;
public interface ILawyerService
{
      public List<LawyerViewModel> GetAll();
      public LawyerViewModel? GetById(int id);
      public LawyerViewModel? GetByCna(string cna);
      public int Create(NewLawyerInputModel lawyer);
      public int CreateLegalCase(int id, NewLegalCaseInputModel legalCase);
      public void Update(int id, NewLawyerInputModel lawyer);
      public void Delete(int id);
}
