using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence;
using TechMed.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TechMed.Application.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly TechMedDbContext _context;

        public MedicoService(TechMedDbContext context)
        {
            _context = context;
        }

        public List<MedicoViewModel> GetAll()
        {
            var medicos = _context.Medicos.Select(m => new MedicoViewModel
            {
                MedicoId = m.MedicoId,
                Name = m.Name,
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
                Name = medico.Name,
                CRM = medico.CRM,
                CPF = medico.CPF
            };

            return medicoViewModel;
        }

        public MedicoViewModel? GetByCrm(string crm)
        {
            var medico = _context.Medicos.FirstOrDefault(m => m.CRM == crm);

            if (medico == null)
                return null;

            var medicoViewModel = new MedicoViewModel
            {
                MedicoId = medico.MedicoId,
                Name = medico.Name,
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
                Name = medico.Name,
                CRM = medico.CRM,
                CPF = medico.CPF
            };

            return medicoViewModel;
        }

        public int Create(NewMedicoInputModel medicoInput)
        {
            var novoMedico = new Medico
            {
                Name = medicoInput.Nome,
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
                Opening = atendimento.DataHora,
                Medico = medico,
                Client = _context.Clients.Find(atendimento.PacienteId),
                SuccessProbability = 1.0f
            };
            _context.Atendimentos.Add(novoAtendimento);
            _context.SaveChanges();

            return novoAtendimento.AtendimentoId;
        }

        public void Update(int id, NewMedicoInputModel medicoInput)
        {
            var medicoExistente = GetById(id);

            if (medicoExistente == null)
            {
                throw new MedicoNotFoundException();
            }

            medicoExistente.Name = medicoInput.Nome;
            medicoExistente.CRM = medicoInput.CRM;
            medicoExistente.CPF = medicoInput.CPF;

            _context.Medicos.Update(medicoExistente);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var medico = GetById(id);

            if (medico != null)
            {
                _context.Medicos.Remove(medico);
                _context.SaveChanges();
            }
        }
    }
}
