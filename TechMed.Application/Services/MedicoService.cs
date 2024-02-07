using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Persistence;
using TechMed.Core.Exceptions;

namespace TechMed.Application.Services;
public class MedicoService : IMedicoService
{
    private readonly TechMedDbContext _context;
    public MedicoService(TechMedDbContext context)
    {
        _context = context;
    }

    private Medico GetByDbId(int id)
    {
        var _medico = _context.Medicos.Find(id);

        if (_medico is null)
            throw new MedicoNotFoundException();
        
        return _medico;
    }

    public int Create(NewMedicoInputModel medico)
    {
        var _medico = new Medico
        {
            Name = medico.Name
        };
        _context.Medicos.Add(_medico);

        _context.SaveChanges();

        return _medico.MedicoId;
    }

    public int CreateAtendimento(int MedicoId, NewAtendimentoInputModel atendimento)
    {
        var _atendimento = new Atendimento
        {
            Opening = atendimento.Opening,
            Medico = GetByDbId(MedicoId),
            Client = _context.Clients.Find(atendimento.ClientId),
            SuccessProbability = 1.0f
        };
        _context.atendimentos.Add(_atendimento);
        _context.SaveChanges();

        return _atendimento.AtendimentoId;
    }

    public void Delete(int id)
    {
        _context.Medico.Remove(GetByDbId(id));

        _context.SaveChanges();
    }

    public List<MedicoViewModel> GetAll()
    {
        var _medicos = _context.Medicos.Select(m => new MedicoViewModel
        {
            MedicoId = m.MedicoId,
            Name = m.Name
        }).ToList();

        return _medicos;
    }

    public MedicoViewModel? GetByCna(string cna)
    {
        throw new NotImplementedException();
    }

    public MedicoViewModel? GetById(int id)
    {
        var _medico = GetByDbId(id);

        var MedicoViewModel = new MedicoViewModel
        {
            MedicoId = _medico.MedicoId,
            Name = _medico.Name
        };
        return MedicoViewModel;
    }

    public void Update(int id, NewMedicoInputModel medico)
    {
        var _medico = GetByDbId(id);

        _medico.Name = medico.Name;

        _context.Medico.Update(_medico);

        _context.SaveChanges();
    }
}