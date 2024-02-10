using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;
using TechMed.Domain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly TechMedDbContext _context;
        private readonly IMedicoService _medicoService;
        private readonly IPacienteService _pacienteService;

        public AtendimentoService(TechMedDbContext context, IMedicoService medicoService, IPacienteService pacienteService)
        {
            _context = context;
            _medicoService = medicoService;
            _pacienteService = pacienteService;
        }

        public List<AtendimentoViewModel> GetAll()
        {
            var atendimentos = _context.Atendimentos.ToList();

            var atendimentosViewModel = new List<AtendimentoViewModel>();

            foreach (var atendimento in atendimentos)
            {
                var atendimentoViewModel = new AtendimentoViewModel
                {
                    AtendimentoId = atendimento.AtendimentoId,
                    Medico = _medicoService.GetById(atendimento.MedicoId),
                    Paciente = _pacienteService.GetById(atendimento.PacienteId)
                };
                atendimentosViewModel.Add(atendimentoViewModel);
            }

            return atendimentosViewModel;
        }

        public AtendimentoViewModel? GetById(int id)
        {
            return _context.Atendimentos
                .Where(a => a.AtendimentoId == id)
                .Select(a => new AtendimentoViewModel
                {
                    AtendimentoId = a.AtendimentoId,
                    Medico = _medicoService.GetById(a.MedicoId),
                    Paciente = _pacienteService.GetById(a.PacienteId)
                })
                .FirstOrDefault();
        }

        public List<AtendimentoViewModel> GetByMedicoId(int medicoId)
        {
            return _context.Atendimentos
                .Where(a => a.MedicoId == medicoId)
                .Select(a => new AtendimentoViewModel
                {
                    AtendimentoId = a.AtendimentoId,
                    Medico = _medicoService.GetById(a.MedicoId),
                    Paciente = _pacienteService.GetById(a.PacienteId)
                })
                .ToList();
        }

        public List<AtendimentoViewModel> GetByPacienteId(int pacienteId)
        {
            return _context.Atendimentos
                .Where(a => a.PacienteId == pacienteId)
                .Select(a => new AtendimentoViewModel
                {
                    AtendimentoId = a.AtendimentoId,
                    Medico = _medicoService.GetById(a.MedicoId),
                    Paciente = _pacienteService.GetById(a.PacienteId)
                })
                .ToList();
        }

        public int Create(NewAtendimentoInputModel atendimento)
        {
            var medico = _medicoService.GetById(atendimento.MedicoId);
            var paciente = _pacienteService.GetById(atendimento.PacienteId);

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
                DataHoraInicio = atendimento.DataHora,
                SuspeitaInicial = atendimento.SuspeitaInicial,
                DataHoraFim = atendimento.DataHoraFim,
                Diagnostico = atendimento.Diagnostico,
                PacienteId = atendimento.PacienteId,
                MedicoId = atendimento.MedicoId,
                Medico = _medicoService.GetByDbId(atendimento.MedicoId),
                Paciente = _pacienteService.GetByDbId(atendimento.PacienteId)
            };

            _context.Atendimentos.Add(newAtendimento);
            _context.SaveChanges();

            return newAtendimento.AtendimentoId;
        }
    }
}
