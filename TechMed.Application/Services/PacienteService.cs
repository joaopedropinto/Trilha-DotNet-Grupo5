using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence;
using TechMed.Core.Exceptions;

namespace TechMed.Application.Services;
public class PacienteService : IPacienteService
{
    private readonly TechMedDbContext _dbcontext;
    public PacienteService(TechMedDbContext dbcontext){
        _dbcontext = dbcontext;
    }
    private Paciente GetByDbId(int id){
        var _paciente = _dbcontext.Pacientes.Find(id);
        if (_paciente is null)
            throw new PacienteNotFoundException();
        
        return _paciente;
    }
    public int Create(NewPacienteInputModel paciente)
    {
        var _paciente = new Paciente
        {
            Name = paciente.Name
        };
        _dbcontext.Pacientes.Add(_paciente);

        _dbcontext.SaveChanges();

        return _paciente.PacienteId;
    }

    public void Delete(int id)
    {
        var _paciente = GetByDbId(id);

        _dbcontext.pacientes.Remove(_paciente);

        _dbcontext.SaveChanges();
    }

    public List<PacienteViewModel> GetAll()
    {
        var _pacientes = _dbcontext.Pacientes.ToList();

        return _pacientes.Select(c => new PacienteViewModel(){
            PacienteId = c.PacienteId,
            Name = c.Name
        }).ToList();
    }

    public PacienteViewModel? GetById(int id)
    {
        var _paciente = GetByDbId(id);

        return new PacienteViewModel(){
            PacienteId = _paciente.PacienteId,
            Name = _paciente.Name
        };
    }

    public void Update(int id, NewPacienteInputModel paciente)
    {
        var _paciente = GetByDbId(id);

        _paciente.Name = paciente.Name;

        _dbcontext.pacientes.Update(_paciente);

        _dbcontext.SaveChanges();
    }
}