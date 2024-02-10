using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;
using TechMed.Infrastructure.Persistence;
using TechMed.Domain.Exceptions;

namespace TechMed.Application.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly TechMedDbContext _context;
        private readonly IPacienteService _pacienteService;

        public MedicoService(TechMedDbContext context, IPacienteService pacienteService)
        {
            _context = context;
            _pacienteService = pacienteService;
        }

        public List<MedicoViewModel> GetAll()
        {
            var medicos = _context.Medicos.Select(m => new MedicoViewModel
            {
                MedicoId = m.MedicoId,
                Nome = m.Nome,
                CRM = m.CRM,
                CPF = m.CPF
            }).ToList();

            return medicos;
        }

        public MedicoViewModel? GetById(int id)
        {
            var medico = _context.Medicos.FirstOrDefault(m => m.MedicoId == id);

            if (medico == null)
                return null;

            var medicoViewModel = new MedicoViewModel
            {
                MedicoId = medico.MedicoId,
                Nome = medico.Nome,
                CRM = medico.CRM,
                CPF = medico.CPF
            };

            return medicoViewModel;
        }

        public Medico GetByDbId(int id)
        {
            var medico = _context.Medicos.Find(id);
            if (medico == null)
                throw new MedicoNotFoundException();

            return medico;
        }

        public MedicoViewModel? GetByCrm(string crm)
        {
            var medico = _context.Medicos.FirstOrDefault(m => m.CRM == crm);

            if (medico == null)
                return null;

            var medicoViewModel = new MedicoViewModel
            {
                MedicoId = medico.MedicoId,
                Nome = medico.Nome,
                CRM = medico.CRM,
                CPF = medico.CPF
            };

            return medicoViewModel;
        }

        public MedicoViewModel? GetByCpf(string cpf)
        {
            var medico = _context.Medicos.FirstOrDefault(m => m.CPF == cpf);

            if (medico == null)
                return null;

            var medicoViewModel = new MedicoViewModel
            {
                MedicoId = medico.MedicoId,
                Nome = medico.Nome,
                CRM = medico.CRM,
                CPF = medico.CPF
            };

            return medicoViewModel;
        }

        public int Create(NewMedicoInputModel medicoInput)
        {
            var novoMedico = new Medico
            {
                Nome = medicoInput.Nome,
                CRM = medicoInput.CRM,
                CPF = medicoInput.CPF
            };
            _context.Medicos.Add(novoMedico);

            _context.SaveChanges();

            return novoMedico.MedicoId;
        }

        public int CreateAtendimento(int medicoId, NewAtendimentoInputModel atendimento)
        {
            var medico = GetById(medicoId);

            if (medico == null)
            {
                throw new MedicoNotFoundException();
            }

            var novoAtendimento = new Atendimento
            {
                DataHoraInicio = atendimento.DataHora,
                SuspeitaInicial = atendimento.SuspeitaInicial,
                DataHoraFim = atendimento.DataHoraFim,
                Diagnostico = atendimento.Diagnostico,
                PacienteId = atendimento.PacienteId,
                MedicoId = medicoId,
                Medico = GetByDbId(medicoId),
                Paciente = _pacienteService.GetByDbId(atendimento.PacienteId)
            };
            _context.Atendimentos.Add(novoAtendimento);
            _context.SaveChanges();

            return novoAtendimento.AtendimentoId;
        }

        public void Update(int id, NewMedicoInputModel medicoInput)
        {
            var medicoExistente = GetByDbId(id);

            if (medicoExistente == null)
            {
                throw new MedicoNotFoundException();
            }

            medicoExistente.Nome = medicoInput.Nome;
            medicoExistente.CRM = medicoInput.CRM;
            medicoExistente.CPF = medicoInput.CPF;

            _context.Medicos.Update(medicoExistente);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var medico = GetByDbId(id);

            if (medico != null)
            {
                _context.Medicos.Remove(medico);
                _context.SaveChanges();
            }
        }
    }
}
