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
   public LegalCaseService (TechAdvocaciaDbContext context, ILawyerService lawyerService, IClientService clientService) 
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
        return _context.LegalCases
            .Where(l => l.LegalCaseId == id)
            .Select(l => new LegalCaseViewModel
            {
                LegalCaseId = l.LegalCaseId,
                Lawyer = _lawyerService.GetById(l.LawyerId),
                Client = _clientService.GetById(l.ClientId),
            })
            .FirstOrDefault();        
    }

    public List<LegalCaseViewModel> GetByLawyerId(int lawyerId){
        return _context.LegalCases
            .Where(l => l.LawyerId == lawyerId)
            .Select(l => new LegalCaseViewModel
            {
                LegalCaseId = l.LegalCaseId,
                Lawyer = _lawyerService.GetById(l.LawyerId),
                Client = _clientService.GetById(l.ClientId),
            })
            .ToList();        
    }

    public List<LegalCaseViewModel> GetByClientId(int clientId){
        return _context.LegalCases
            .Where(l => l.ClientId == clientId)
            .Select(l => new LegalCaseViewModel
            {
                LegalCaseId = l.LegalCaseId,
                Lawyer = _lawyerService.GetById(l.LawyerId),
                Client = _clientService.GetById(l.ClientId),
            })
            .ToList();        
    }

    public int Create(NewLegalCaseInputModel legalCase)
    {
        var lawyer = _lawyerService.GetById(legalCase.LawyerId);
        var client = _clientService.GetById(legalCase.ClientId);

        if (lawyer == null)
        {
            throw new LawyerNotFoundException();
        }

        if (client == null)
        {
            throw new ClientNotFoundException();
        }

        var newLegalCase = new LegalCase
        {
            LawyerId = legalCase.LawyerId,
            ClientId = legalCase.ClientId,
        };

        _context.LegalCases.Add(newLegalCase);
        _context.SaveChanges();

        return newLegalCase.LegalCaseId;
    }
    
}