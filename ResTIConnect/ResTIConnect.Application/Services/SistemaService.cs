using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Context;
using ResTIConnect.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

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

        foreach (var userId in sistema.UsuarioIds ?? new List<int>())
        {
            var usuario = _dbcontext.Usuarios.FirstOrDefault(u => u.UsuarioId == userId);
            if (usuario != null)
            {
                _sistema.Usuarios.Add(usuario);
            }
            else
            {
            }
        }

        foreach (var EventoId in sistema.EventoIds ?? new List<int>())
        {
            var evento = _dbcontext.Eventos.FirstOrDefault(u => u.EventoId == EventoId);
            if (evento != null)
            {
                _sistema.Eventos.Add(evento);
            }
            else
            {
            }
        }

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
        var _sistemas = _dbcontext.Sistemas
            .Include(u => u.Usuarios)
            .Include(u => u.Eventos)
            .ToList();

        return _sistemas.Select(c => new SistemaViewModel()
        {
            Sistemald = c.Sistemald,
            Descricao = c.Descricao,
            Tipo = c.Tipo,
            EnderecoEntrada = c.EnderecoEntrada,
            EnderecoSaida = c.EnderecoSaida,
            Protocolo = c.Protocolo,
            DataHoraInicioIntegracao = c.DataHoraInicioIntegracao,
            Status = c.Status,
            Usuarios = c.Usuarios?.Select(p => new UsuarioViewModel
            {
                UsuarioId = p.UsuarioId,
                Nome = p.Nome,
                Apelido = p.Apelido,
                Email = p.Email,
                Senha = p.Senha,
                Telefone = p.Telefone,
            }).ToList() ?? new List<UsuarioViewModel>(),
            Eventos = c.Eventos.Select(e => new EventoViewModel
            {
                EventoId = e.EventoId,
                Tipo = e.Tipo,
                Descricao = e.Descricao,
                Codigo = e.Codigo,
                Conteudo = e.Conteudo,
                DataHoraOcorrencia = e.DataHoraOcorrencia
            }).ToList()
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

    public List<SistemaViewModel> GetSistemasByUserId(int userId)
    {
        var sistemas = _dbcontext.Sistemas
            .Where(s => s.Usuarios.Any(u => u.UsuarioId == userId))
            .Select(s => new SistemaViewModel
            {
                Sistemald = s.Sistemald,
                Descricao = s.Descricao,
                Tipo = s.Tipo,
                EnderecoEntrada = s.EnderecoEntrada,
                EnderecoSaida = s.EnderecoSaida,
                Protocolo = s.Protocolo,
                DataHoraInicioIntegracao = s.DataHoraInicioIntegracao,
                Status = s.Status,
                Usuarios = s.Usuarios.Select(u => new UsuarioViewModel
                {
                    UsuarioId = u.UsuarioId,
                    Nome = u.Nome,
                    Apelido = u.Apelido,
                    Email = u.Email,
                    Senha = u.Senha,
                    Telefone = u.Telefone
                }).ToList(),
            })
            .ToList();

        return sistemas;
    }

    public List<SistemaViewModel> GetSystemsByEventFromDate(string type, DateTimeOffset fromDate)
    {
        return _dbcontext.Sistemas
            .Where(s => s.Eventos.Any(e => e.Tipo == type && e.DataHoraOcorrencia >= fromDate && e.DataHoraOcorrencia <= DateTimeOffset.Now))
            .Select(s => new SistemaViewModel
            {
                Sistemald = s.Sistemald,
                Descricao = s.Descricao,
                Tipo = s.Tipo,
                EnderecoEntrada = s.EnderecoEntrada,
                EnderecoSaida = s.EnderecoSaida,
                Protocolo = s.Protocolo,
                DataHoraInicioIntegracao = s.DataHoraInicioIntegracao,
                Status = s.Status,
                Usuarios = s.Usuarios.Select(u => new UsuarioViewModel
                {
                    UsuarioId = u.UsuarioId,
                    Nome = u.Nome,
                    Apelido = u.Apelido,
                    Email = u.Email,
                    Senha = u.Senha,
                    Telefone = u.Telefone,
                }).ToList(),
                Eventos = s.Eventos.Select(e => new EventoViewModel
                {
                    EventoId = e.EventoId,
                    Tipo = e.Tipo,
                    Descricao = e.Descricao,
                    Codigo = e.Codigo,
                    Conteudo = e.Conteudo,
                    DataHoraOcorrencia = e.DataHoraOcorrencia
                }).ToList()
            }).ToList();
    }

    public void Update(int id, NewSistemaInputModel sistema)
    {
        try
        {
            var sistemaToUpdate = GetByDbId(id);

            sistemaToUpdate.Descricao = sistema.Descricao;
            sistemaToUpdate.Tipo = sistema.Tipo;
            sistemaToUpdate.EnderecoEntrada = sistema.EnderecoEntrada;
            sistemaToUpdate.EnderecoSaida = sistema.EnderecoSaida;
            sistemaToUpdate.Protocolo = sistema.Protocolo;
            sistemaToUpdate.DataHoraInicioIntegracao = sistema.DataHoraInicioIntegracao;
            sistemaToUpdate.Status = sistema.Status;

            sistemaToUpdate.Usuarios.Clear();
            foreach (var userId in sistema.UsuarioIds ?? new List<int>())
            {
                var usuario = _dbcontext.Usuarios.FirstOrDefault(u => u.UsuarioId == userId);
                if (usuario != null)
                {
                    sistemaToUpdate.Usuarios.Add(usuario);
                }
            }

            sistemaToUpdate.Eventos.Clear();
            foreach (var eventoId in sistema.EventoIds ?? new List<int>())
            {
                var evento = _dbcontext.Eventos.FirstOrDefault(e => e.EventoId == eventoId);
                if (evento != null)
                {
                    sistemaToUpdate.Eventos.Add(evento);
                }
            }

            _dbcontext.SaveChanges();
        }
        catch (Exception ex)
        {
            // Captura a exceção e trata de acordo
            throw new Exception("Ocorreu um erro ao atualizar o sistema. Consulte a exceção interna para obter detalhes.", ex);
        }
    }

}
