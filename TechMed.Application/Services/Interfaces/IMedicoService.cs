using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Domain.Entities;

namespace TechMed.Application.Services.Interfaces;

public interface IMedicoService
{
      public List<MedicoViewModel> GetAll();
      public MedicoViewModel? GetById(int id);
      public Medico GetByDbId(int id);
      public MedicoViewModel? GetByCrm(string crm);
      public MedicoViewModel? GetByCpf(string cpf);
      public int Create(NewMedicoInputModel medico);
      public int CreateAtendimento(int medicoId,NewAtendimentoInputModel atendimento);
      public void Update(int id, NewMedicoInputModel medico);
      public void Delete(int id);
}