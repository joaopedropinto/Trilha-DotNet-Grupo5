using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;
using TechMed.Infrastructure.Persistence;
using TechMed.Domain.Exceptions;
using TechMed.Application.Services.Interfaces;

namespace TechMed.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly TechMedDbContext _dbContext;

        public PacienteService(TechMedDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Paciente GetByDbId(int id)
        {
            var paciente = _dbContext.Pacientes.Find(id);
            if (paciente == null)
                throw new PacienteNotFoundException();
        
            return paciente;
        }

        public List<PacienteViewModel> GetAll()
        {
            var pacientes = _dbContext.Pacientes.ToList();

            return pacientes.Select(p => new PacienteViewModel()
            {
                PacienteId = p.PacienteId,
                Nome = p.Nome,
                CPF = p.CPF 
            }).ToList();
        }

        public PacienteViewModel? GetById(int id)
        {
            var paciente = GetByDbId(id);

            return new PacienteViewModel()
            {
                PacienteId = paciente.PacienteId,
                Nome = paciente.Nome,
                CPF = paciente.CPF
            };
        }


        public PacienteViewModel? GetByCpf(string cpf)
        {
            var paciente = _dbContext.Pacientes.FirstOrDefault(p => p.CPF == cpf);

            if (paciente == null)
                return null;

            var pacienteViewModel = new PacienteViewModel
            {
                PacienteId = paciente.PacienteId,
                Nome = paciente.Nome,
                CPF = paciente.CPF
            };

            return pacienteViewModel;
        }

        public int Create(NewPacienteInputModel pacienteInput)
        {
            var novoPaciente = new Paciente
            {
                Nome = pacienteInput.Nome,
                CPF = pacienteInput.CPF,
                DataNascimento = pacienteInput.DataNascimento
            };
            _dbContext.Pacientes.Add(novoPaciente);

            _dbContext.SaveChanges();

            return novoPaciente.PacienteId;
        }

        public void Update(int id, NewPacienteInputModel pacienteInput)
        {
            var paciente = GetByDbId(id);

            paciente.Nome = pacienteInput.Nome;
            paciente.CPF = pacienteInput.CPF;
            paciente.DataNascimento = pacienteInput.DataNascimento;

            _dbContext.Pacientes.Update(paciente);

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var paciente = GetByDbId(id);

            _dbContext.Pacientes.Remove(paciente);

            _dbContext.SaveChanges();
        }
    }
}
