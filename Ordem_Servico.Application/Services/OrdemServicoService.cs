using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Domain;
namespace Ordem_Servico.Application.Services;

public class OrdemServicoService : IOrdemServicoService
{
    private readonly OrdemServicoContext _dbcontext;
    public OrdemServicoService(OrdemServicoContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    private OrdemServico GetByDbId(int id)
    {
        var _ordemServico = _dbcontext.OrdemServico.Find(id);
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
            Finalizacao = ordemServico.Finalizacao,
        };

        // Mapeie ou crie os equipamentos com base nos IDs fornecidos
        if (ordemServico.EquipamentosIDs != null && ordemServico.EquipamentosIDs.Any())
        {
            _ordemServico.Equipamentos = _dbcontext.Equipamento
                                            .Where(e => ordemServico.EquipamentosIDs.Contains(e.EquipamentoID))
                                            .ToList();
        }

        if (ordemServico.ServicosIDs != null && ordemServico.ServicosIDs.Any())
        {
            _ordemServico.Servicos = _dbcontext.Servico
                                            .Where(e => ordemServico.ServicosIDs.Contains(e.ServicoID))
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
        var _ordemServicos = _dbcontext.OrdemServico.ToList();

        return _ordemServicos.Select(ordemServico => new OrdemServicoViewModel()
        {
            Prazo = ordemServico.Prazo,
            FormaPagamento = ordemServico.FormaPagamento,
            Status = ordemServico.Status,
            ClienteID = ordemServico.ClienteID,
            TecnicoID = ordemServico.TecnicoID,
            Finalizacao = ordemServico.Finalizacao,
            Equipamentos = (ICollection<int>)ordemServico.Equipamentos,
            Servicos = (ICollection<int>)ordemServico.Servicos,
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
            Finalizacao = _ordemServico.Finalizacao,
            Equipamentos = (ICollection<int>)_ordemServico.Equipamentos,
            Servicos = (ICollection<int>)_ordemServico.Servicos,
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
        _ordemServico.Finalizacao = ordemServico.Finalizacao;

        _dbcontext.OrdemServico.Update(_ordemServico);

        _dbcontext.SaveChanges();
    }
}
