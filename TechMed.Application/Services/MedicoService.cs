using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Infrastructure.Persistence.Interfaces;
using TechMed.Core.Entities;
using TechMed.Core.Exceptions;

namespace TechMed.Application.Services;
public class MedicoService : IMedicoService
{
  private readonly ITechMedContext _context;
  public MedicoService(ITechMedContext context)
  {
    _context = context;
  }

  public int Create(NewMedicoInputModel medico)
  {
    return _context.MedicosCollection.Create(new Medico
    {
      Nome = medico.Nome,
      CRM = medico.CRM,
      CPF = medico.CPF
    });

  }

  public int CreateAtendimento(int medicoId, NewAtendimentoInputModel atendimento)
  {
    var medico = _context.MedicosCollection.GetById(medicoId);
    if (medico is null)
      throw new MedicoNotFoundException();

    var paciente = _context.PacientesCollection.GetById(atendimento.PacienteId);
    if (paciente is null)
      throw new PacienteNotFoundException();

    return _context.AtendimentosCollection.Create(new Atendimento
    {
      DataHora = atendimento.DataHora,
      Medico = medico,
      Paciente = paciente
    });
  }

  public void Delete(int id)
  {
    _context.MedicosCollection.Delete(id);
  }

  public List<MedicoViewModel> GetAll()
  {
    var medicos = _context.MedicosCollection.GetAll().Select(m => new MedicoViewModel
    {
      MedicoId = m.MedicoId,
      Nome = m.Nome,
      CRM = m.CRM,
      CPF = m.CPF
    }).ToList();

    return medicos;

  }

  public MedicoViewModel? GetByCrm(string crm)
  {
    throw new NotImplementedException();
  }

  public MedicoViewModel? GetById(int id)
  {
    var medico = _context.MedicosCollection.GetById(id);

    if (medico is null)
      return null;

    var MedicoViewModel = new MedicoViewModel
    {
      MedicoId = medico.MedicoId,
      Nome = medico.Nome,
      CRM = medico.CRM,
      CPF = medico.CPF
    };
    return MedicoViewModel;
  }

  public void Update(int id, NewMedicoInputModel medico)
  {
    _context.MedicosCollection.Update(id, new Medico
    {
      Nome = medico.Nome,
      CRM = medico.CRM,
      CPF = medico.CPF
    });
  }
}