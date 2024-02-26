using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Context;
using ResTIConnect.Domain.Exceptions;

namespace ResTIConnect.Application.Services;
public class LogService : ILogService
{
    private readonly ResTIConnectContext _dbcontext;
    public LogService(ResTIConnectContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    private Log GetByDbId(int id)
    {
        var _log = _dbcontext.Logs.Find(id);
        if (_log is null)
        {
            throw new LogAlreadyExistsException();//fazer as exceptions pra adicionar aqui
        }
        return _log;
    }

    public int Create(NewLogInputModel log)
    {
        var _log = new Log
        {
            Tipo = log.Tipo,
            Descricao = log.Descricao,
            DataHoraEvento = log.DataHoraEvento,
            Entidade = log.Entidade,
            Endereco = log.Endereco

        };
        _dbcontext.Logs.Add(_log);
        _dbcontext.SaveChanges();
        return _log.LogId;
    }

    public void Delete(int id)
    {
        var _log = GetByDbId(id);
        _dbcontext.Logs.Remove(_log);
        _dbcontext.SaveChanges();
    }

    public List<LogViewModel> GetAll()
    {
        var _logs = _dbcontext.Logs.ToList();
        return _logs.Select(c => new LogViewModel()
        {
            LogId = c.LogId,
            Tipo = c.Tipo,
            Descricao = c.Descricao,
            DataHoraEvento = c.DataHoraEvento,
            Entidade = c.Entidade,
            Endereco = c.Endereco
        }).ToList();
    }
    public LogViewModel? GetById(int id)
    {

        var _log = GetByDbId(id);

        return new LogViewModel()
        {
            LogId = _log.LogId,
            Descricao = _log.Descricao,
            DataHoraEvento = _log.DataHoraEvento,
            Entidade = _log.Entidade,
            Endereco = _log.Endereco
        };
    }

    public void Update(int id, NewLogInputModel log)
    {
        var _log = GetByDbId(id);
        _log.Tipo = log.Tipo;
        _dbcontext.Logs.Update(_log);
        _dbcontext.SaveChanges();
    }
}
