using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.Interfaces;

public interface IPacienteService
{
      public List<PacienteViewModel> GetAll();
      public PacienteViewModel? GetById(int id);
      public PacienteViewModel? GetByCpf(string cpf);
      public int Create(NewPacienteInputModel medico);
      public void Update(int id, NewPacienteInputModel medico);
      public void Delete(int id);
}