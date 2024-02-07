using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Core.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application.Services;
/* public interface IAtendimentoService
{
   public List<AtendimentoViewModel> GetAll();
   public AtendimentoViewModel? GetById(int id);
   public List<AtendimentoViewModel> GetByLawyerId(int lawyerId);
   public List<AtendimentoViewModel> GetByClientId(int clientId);
   public int Create(NewLegalCaseInputModel legalCase);
} */
public class AtendimentoService : IAtendimentoService
{
    private readonly TechMedDbContext _context;
   private readonly IMedicoService _medicos;
   private readonly IPacienteService _pacienteService;
   public AtendimentoService (TechMedDbContext context, IMedicoService lawyerService, IPacienteService clientService) 
   {
        _context = context;
        _medicos = lawyerService;
        _pacienteService = clientService;
   }

    public List<AtendimentoViewModel> GetAll()
    {
        var atendimentos = _context.LegalCases.ToList();

        var legalCasesViewModel = new List<AtendimentoViewModel>();

        foreach (var atendimento in atendimentos)
        {
            var AtendimentoViewModel = new AtendimentoViewModel
            {
                AtendimentoId = atendimento.AtendimentoId,
                Medico = _medicoService.GetById(atendimento.LawyerId),
                Paciente = _pacienteService.GetById(atendimento.ClientId),
            };
            legalCasesViewModel.Add(AtendimentoViewModel);
        }

        return legalCasesViewModel;
    }

    public AtendimentoViewModel? GetById(int id){
        return _context.Atendimentos
            .Where(l => l.AtendimentoId == id)
            .Select(l => new AtendimentoViewModel
            {
                AtendimentoId = l.AtendimentoId,
                Medico = _medicos.GetById(l.medicoId),
                Paciente = _pacienteService.GetById(l.PacienteId),
            })
            .FirstOrDefault();        
    }

    public List<AtendimentoViewModel> GetByMedicoId(int MedicoId){
        return _context.Atendimentos
            .Where(l => l.M == MedicoId)
            .Select(l => new AtendimentoViewModel
            {
                AtendimentoId = l.AtendimentoId,
                Medico = _medicoService.GetById(l.MedicoId),
                Paciente = _pacienteService.GetById(l.PacienteId),
            })
            .ToList();        
    }

    public List<AtendimentoViewModel> GetByPacienteId(int pacienteId){
        return _context.Atendimentos
            .Where(l => l.ClientId == pacienteId)
            .Select(l => new AtendimentoViewModel
            {
                AtendimentoId = l.AtendimentoId,
                Medico = _medicos.GetById(l.MedicoId),
                Paciente = _pacienteService.GetById(l.PacienteId),
            })
            .ToList();        
    }

    public int Create(NewAtemdimentoInputModel atendimento)
    {
        var medico = _medicos.GetById(atendimento.MedicoId);
        var paciente = _pacienteService.GetById(atendimento.pacienteId);

        if (medico == null)
        {
            throw new MedicoNotFoundException();
        }

        if (paciente == null)
        {
            throw new PacienteNotFoundException();
        }

        var newAtendimento = new Atendimento
        {
            MedicoId = atendimento.LawyerId,
            PacienteId = atendimento.ClientId,
        };

        _context.Atendimentos.Add(newAtendimento);
        _context.SaveChanges();

        return newAtendimento.AtendimentoId;
    }
    
}