using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Core.Entities;
using TechAdvocacia.Core.Exceptions;
using TechAdvocacia.Infrastructure.Persistence;

namespace TechAdvocacia.Application.Services;
/* public interface ILegalCaseService
{
   public List<LegalCaseViewModel> GetAll();
   public LegalCaseViewModel? GetById(int id);
   public List<LegalCaseViewModel> GetByLawyerId(int lawyerId);
   public List<LegalCaseViewModel> GetByClientId(int clientId);
   public int Create(NewLegalCaseInputModel legalCase);
} */
public class LegalCaseService : ILegalCaseService
{
    private readonly TechAdvocaciaDbContext _context;
   private readonly ILawyerService _lawyerService;
   private readonly IClientService _clientService;
   public LegalCaseService (TechAdvocaciaDbContext context, ILawyerService lawyerService, IClientService clientService) : base(context)
   {
        _context = context;
        _lawyerService = lawyerService;
        _clientService = clientService;
   }

    public List<LegalCaseViewModel> GetAll()
    {
        var legalCases = _context.LegalCases.ToList();

        var legalCasesViewModel = new List<LegalCaseViewModel>();

        foreach (var legalCase in legalCases)
        {
            var legalCaseViewModel = new LegalCaseViewModel
            {
                LegalCaseId = legalCase.LegalCaseId,
                Lawyer = _lawyerService.GetById(legalCase.LawyerId),
                Client = _clientService.GetById(legalCase.ClientId),
            };
            legalCasesViewModel.Add(legalCaseViewModel);
        }

        return legalCasesViewModel;
    }

    public LegalCaseViewModel? GetById(int id){
        
    }
}
    }
}