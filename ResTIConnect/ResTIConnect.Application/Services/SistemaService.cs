using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Context;
using ResTIConnect.Domain.Exceptions;

namespace ResTIConnect.Application.Services;
public class SistemaService : ISistemaService
{
    private readonly ResTIConnectContext _dbcontext;
    public SistemaService(ResTIConnectContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    private Sistema GetByDbId(int id)
    {
        var _sistema = _dbcontext.Sistemas.Find(id);
        if (_sistema is null)
        {
            throw new SistemaAlreadyExistsException();//fazer as exceptions pra adicionar aqui
        }
        return _sistema;
    }

    public int Create(NewSistemaInputModel sistema)
    {
        var _sistema = new Sistema
        {
            Descricao = sistema.Descricao,
            Tipo = sistema.Tipo,
            EnderecoEntrada = sistema.EnderecoEntrada,
            EnderecoSaida = sistema.EnderecoSaida,
            Protocolo = sistema.Protocolo,
            DataHoraInicioIntegracao = sistema.DataHoraInicioIntegracao,
            Status = sistema.Status
        };
        _dbcontext.Sistemas.Add(_sistema);
        _dbcontext.SaveChanges();
        return _sistema.Sistemald;
    }

    public void Delete(int id)
    {
        var _sistema = GetByDbId(id);
        _dbcontext.Sistemas.Remove(_sistema);
        _dbcontext.SaveChanges();
    }

    public List<SistemaViewModel> GetAll()
    {
        var _sistemas = _dbcontext.Sistemas.ToList();
        return _sistemas.Select(c => new SistemaViewModel()
        {
            Sistemald = c.Sistemald,
            Descricao = c.Descricao,
            Tipo = c.Tipo,
            EnderecoEntrada = c.EnderecoEntrada,
            EnderecoSaida = c.EnderecoSaida,
            Protocolo = c.Protocolo,
            DataHoraInicioIntegracao = c.DataHoraInicioIntegracao,
            Status = c.Status
        }).ToList();
    }
    public SistemaViewModel? GetById(int id)
    {

        var _sistema = GetByDbId(id);

        return new SistemaViewModel()
        {
            Sistemald = _sistema.Sistemald,
            Descricao = _sistema.Descricao,
            Tipo = _sistema.Tipo,
            EnderecoEntrada = _sistema.EnderecoEntrada,
            EnderecoSaida = _sistema.EnderecoSaida,
            Protocolo = _sistema.Protocolo,
            DataHoraInicioIntegracao = _sistema.DataHoraInicioIntegracao,
            Status = _sistema.Status
        };
    }

    public void Update(int id, NewSistemaInputModel sistema)
    {
        var _sistema = GetByDbId(id);
        _sistema.Descricao = sistema.Descricao;
        _dbcontext.Sistemas.Update(_sistema);
        _dbcontext.SaveChanges();
    }
}
