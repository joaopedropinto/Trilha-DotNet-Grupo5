using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Context;
using ResTIConnect.Domain.Exceptions;

namespace ResTIConnect.Application.Services;
public class EventoService : IEventoService
{
    private readonly ResTIConnectContext _dbcontext;
    public EventoService(ResTIConnectContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    private Evento GetByDbId(int id)
    {
        var _evento = _dbcontext.Eventos.Find(id);
        if (_evento is null)
        {
            throw new EventoAlreadyExistsException();//fazer as exceptions pra adicionar aqui
        }
        return _evento;
    }

    public int Create(NewEventoInputModel evento)
    {
        var _evento = new Evento
        {
            Tipo = evento.Tipo,
            Descricao = evento.Descricao,
            Codigo = evento.Codigo,
            Conteudo = evento.Conteudo,
            DataHoraOcorrencia = evento.DataHoraOcorrencia

        };
        _dbcontext.Eventos.Add(_evento);
        _dbcontext.SaveChanges();
        return _evento.EventoId;
    }

    public void Delete(int id)
    {
        var _evento = GetByDbId(id);
        _dbcontext.Eventos.Remove(_evento);
        _dbcontext.SaveChanges();
    }

    public List<EventoViewModel> GetAll()
    {
        var _eventos = _dbcontext.Eventos.ToList();
        return _eventos.Select(c => new EventoViewModel()
        {
            EventoId = c.EventoId,
            Tipo = c.Tipo,
            Descricao = c.Descricao,
            Codigo = c.Codigo,
            Conteudo = c.Conteudo,
            DataHoraOcorrencia = c.DataHoraOcorrencia
        }).ToList();
    }
    public EventoViewModel? GetById(int id)
    {

        var _evento = GetByDbId(id);

        return new EventoViewModel()
        {
            EventoId = _evento.EventoId,
            Descricao = _evento.Descricao,
            Codigo = _evento.Codigo,
            Conteudo = _evento.Conteudo,
            DataHoraOcorrencia = _evento.DataHoraOcorrencia
        };
    }

    public void Update(int id, NewEventoInputModel evento)
    {
        var _evento = GetByDbId(id);
        _evento.Tipo = evento.Tipo;
        _dbcontext.Eventos.Update(_evento);
        _dbcontext.SaveChanges();
    }
}
