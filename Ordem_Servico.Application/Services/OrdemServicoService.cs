using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Domain;
namespace Ordem_Servico.Application.Services;
using Microsoft.EntityFrameworkCore;

public class OrdemServicoService : IOrdemServicoService
{
    private readonly OrdemServicoContext _dbcontext;
    public OrdemServicoService(OrdemServicoContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    private OrdemServico GetByDbId(int id)
    {
        var _ordemServico = _dbcontext.OrdemServico
                            .Include(o => o.Finalizacao)
                            .Include(o => o.Equipamentos)
                            .Include(o => o.Servicos)
                            .Include(o => o.Ocorrencias)
                            .Include(o => o.Pecas)
                            .FirstOrDefault(o => o.OrdemServicoID == id);
        if (_ordemServico is null)
            throw new Exception();

        return _ordemServico;
    }
    public int Create(NewOrdemServicoInputModel ordemServico)
    {
        var _ordemServico = new OrdemServico
        {
            Prazo = ordemServico.Prazo,
            FormaPagamento = ordemServico.FormaPagamento,
            Status = ordemServico.Status,
            ClienteID = ordemServico.ClienteID,
            TecnicoID = ordemServico.TecnicoID,
            Finalizacao = _dbcontext.Finalizacao.Find(ordemServico.FinalizacaoID) ?? null,
        };

        // Mapeie ou crie os equipamentos com base nos IDs fornecidos
        if (ordemServico.EquipamentosIDs != null && ordemServico.EquipamentosIDs.Any())
        {
            _ordemServico.Equipamentos = _dbcontext.Equipamento
                                            .Where(e => ordemServico.EquipamentosIDs.Contains(e.EquipamentoID))
                                            .ToList();
        }

        _dbcontext.OrdemServico.Add(_ordemServico);
        _dbcontext.SaveChanges();

        return _ordemServico.OrdemServicoID;
    }

    public void Delete(int id)
    {
        var _ordemServico = GetByDbId(id);

        _dbcontext.OrdemServico.Remove(_ordemServico);

        _dbcontext.SaveChanges();
    }

    public List<OrdemServicoViewModel> GetAll()
    {
        var _ordemServicos = _dbcontext.OrdemServico
                            .Include(o => o.Finalizacao)
                            .Include(o => o.Equipamentos)
                            .Include(o => o.Servicos)
                            .Include(o => o.Ocorrencias)
                            .Include(o => o.Pecas)
                            .ToList();

        return _ordemServicos.Select(ordemServico => new OrdemServicoViewModel()
        {
            OrdemServicoID = ordemServico.OrdemServicoID,
            Prazo = ordemServico.Prazo,
            FormaPagamento = ordemServico.FormaPagamento,
            Status = ordemServico.Status,
            ClienteID = ordemServico.ClienteID,
            TecnicoID = ordemServico.TecnicoID,
            Finalizacao =  ordemServico.Finalizacao != null ? new FinalizacaoViewModel()
            {
                FinalizacaoID = ordemServico.Finalizacao.FinalizacaoID,
                DataFinalizacao = ordemServico.Finalizacao.DataFinalizacao,
                Comentario = ordemServico.Finalizacao.Comentario,
            } : null,
            EquipamentosIDs = ordemServico.Equipamentos?.Select(e => e.EquipamentoID).ToList(),
            ServicosIDs = ordemServico.Servicos?.Select(s => s.ServicoID).ToList(),
            OcorrenciasIDs = ordemServico.Ocorrencias?.Select(o => o.OcorrenciaID).ToList(),
            PecasIDs = ordemServico.Pecas?.Select(p => p.PecaID).ToList(),
        }).ToList();
    }

    public OrdemServicoViewModel? GetById(int id)
    {
        var _ordemServico = GetByDbId(id);

        return new OrdemServicoViewModel()
        {
            Prazo = _ordemServico.Prazo,
            FormaPagamento = _ordemServico.FormaPagamento,
            Status = _ordemServico.Status,
            ClienteID = _ordemServico.ClienteID,
            TecnicoID = _ordemServico.TecnicoID,
            Finalizacao = new FinalizacaoViewModel()
            {
                FinalizacaoID = _ordemServico.Finalizacao?.FinalizacaoID ?? 0,
                DataFinalizacao = _ordemServico.Finalizacao?.DataFinalizacao ?? DateTime.MinValue,
                Comentario = _ordemServico.Finalizacao?.Comentario ?? "",
            },
            EquipamentosIDs = _ordemServico.Equipamentos?.Select(e => e.EquipamentoID).ToList(),
            ServicosIDs = _ordemServico.Servicos?.Select(s => s.ServicoID).ToList(),
            OcorrenciasIDs = _ordemServico.Ocorrencias?.Select(o => o.OcorrenciaID).ToList(),
            PecasIDs = _ordemServico.Pecas?.Select(p => p.PecaID).ToList()
        };
    }

    public void Update(int id, NewOrdemServicoInputModel ordemServico)
    {
        var _ordemServico = GetByDbId(id);

        _ordemServico.Prazo = ordemServico.Prazo;
        _ordemServico.FormaPagamento = ordemServico.FormaPagamento;
        _ordemServico.Status = ordemServico.Status;
        _ordemServico.ClienteID = ordemServico.ClienteID;
        _ordemServico.TecnicoID = ordemServico.TecnicoID;
        _ordemServico.Finalizacao = _dbcontext.Finalizacao.Find(ordemServico.FinalizacaoID) ?? null;
        _ordemServico.Equipamentos = _dbcontext.Equipamento
                                    .Where(e => ordemServico.EquipamentosIDs.Contains(e.EquipamentoID))
                                    .ToList();

        _dbcontext.OrdemServico.Update(_ordemServico);

        _dbcontext.SaveChanges();
    }
}
