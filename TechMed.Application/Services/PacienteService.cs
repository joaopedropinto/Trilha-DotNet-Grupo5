using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence;
using TechMed.Core.Exceptions;

namespace TechMed.Application.Services;
public class PacienteService : IPacienteService
{
    private readonly TechMedDbContext _context;
    public PacienteService(TechMedDbContext context)
    {
        _context = context;
    }

    private Paciente GetByDbId(int id)
    {
        var _paciente = _context.Pacientes.Find(id);

        if (_paciente is null)
            throw new PacienteNotFoundException();
        
        return _paciente;
    }

    public int Create(NewPacienteInputModel medico)
    {
        var _paciente = new Paciente
        {
            Nome = medico.Nome,
            CPF = medico.CPF,
            DataNascimento = medico.DataNascimento
        };
        _context.Pacientes.Add(_paciente);

        _context.SaveChanges();

        return _paciente.PacienteId;
    }

    public void Delete(int id)
    {
        _context.Pacientes.Remove(GetByDbId(id));

        _context.SaveChanges();
    }

    public List<PacienteViewModel> GetAll()
    {
        var _pacientes = _context.Pacientes.Select(m => new PacienteViewModel
        {
            PacienteId = m.PacienteId,
            Nome = m.Nome,
            CPF = m.CPF,
            DataNascimento = m.DataNascimento
        }).ToList();

        return _pacientes;
    }

    public PacienteViewModel? GetById(int id)
    {
        var _paciente = GetByDbId(id);

        var PacienteViewModel = new PacienteViewModel
        {
            PacienteId = _paciente.PacienteId,
            Nome = _paciente.Nome,
            CPF = _paciente.CPF,
            DataNascimento = _paciente.DataNascimento
        };
        return PacienteViewModel;
    }

    public void Update(int id, NewPacienteInputModel medico)
    {
        var _paciente = GetByDbId(id);

        _paciente.Nome = medico.Nome;
        _paciente.CPF = medico.CPF;
        _paciente.DataNascimento = medico.DataNascimento;

        _context.Pacientes.Update(_paciente);

        _context.SaveChanges();
    }
}