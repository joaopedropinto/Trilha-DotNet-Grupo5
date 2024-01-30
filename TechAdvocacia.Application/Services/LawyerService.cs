using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Core.Entities;
using TechAdvocacia.Infrastructure.Persistence;
using TechAdvocacia.Core.Exceptions;

namespace TechAdvocacia.Application.Services;
public class LawyerService : ILawyerService
{
    private readonly TechAdvocaciaDbContext _context;
    public LawyerService(TechAdvocaciaDbContext context)
    {
        _context = context;
    }

    private Lawyer GetByDbId(int id)
    {
        var _lawyer = _context.Lawyers.Find(id);

        if (_lawyer is null)
            throw new LawyerNotFoundException();
        
        return _lawyer;
    }

    public int Create(NewLawyerInputModel lawyer)
    {
        var _lawyer = new Lawyer
        {
            Name = lawyer.Name
        };
        _context.Lawyers.Add(_lawyer);

        _context.SaveChanges();

        return _lawyer.LawyerId;
    }

    public int CreateLegalCase(int lawyerId, NewLegalCaseInputModel legalCase)
    {
        var _legalCase = new LegalCase
        {
            Opening = legalCase.Opening,
            Lawyer = GetByDbId(lawyerId),
            Client = _context.Clients.Find(legalCase.ClientId),
            SuccessProbability = 1.0f
        };
        _context.LegalCases.Add(_legalCase);
        _context.SaveChanges();

        return _legalCase.LegalCaseId;
    }

    public void Delete(int id)
    {
        _context.Lawyers.Remove(GetByDbId(id));

        _context.SaveChanges();
    }

    public List<LawyerViewModel> GetAll()
    {
        var _lawyers = _context.Lawyers.Select(m => new LawyerViewModel
        {
            LawyerId = m.LawyerId,
            Name = m.Name
        }).ToList();

        return _lawyers;
    }

    public LawyerViewModel? GetByCna(string cna)
    {
        throw new NotImplementedException();
    }

    public LawyerViewModel? GetById(int id)
    {
        var _lawyer = GetByDbId(id);

        var LawyerViewModel = new LawyerViewModel
        {
            LawyerId = _lawyer.LawyerId,
            Name = _lawyer.Name
        };
        return LawyerViewModel;
    }

    public void Update(int id, NewLawyerInputModel lawyer)
    {
        var _lawyer = GetByDbId(id);

        _lawyer.Name = lawyer.Name;

        _context.Lawyers.Update(_lawyer);

        _context.SaveChanges();
    }
}
