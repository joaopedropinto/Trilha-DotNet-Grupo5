using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;

namespace TechAdvocacia.Application.Services.Interfaces;
public interface ILegalCaseService
{
   public List<LegalCaseViewModel> GetAll();
   public LegalCaseViewModel? GetById(int id);
   public List<LegalCaseViewModel> GetByLawyerId(int lawyerId);
   public List<LegalCaseViewModel> GetByClientId(int clientId);
   public int Create(NewLegalCaseInputModel legalCase);
}