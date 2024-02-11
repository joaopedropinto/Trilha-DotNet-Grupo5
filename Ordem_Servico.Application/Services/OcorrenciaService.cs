using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Domain;

namespace Ordem_Servico.Application.Services;

public class OcorrenciaService : IOcorrenciaService
{
    private readonly OrdemServicoContext _dbcontext;  

    public OcorrenciaService(OrdemServicoContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    private Ocorrencia GetByDbId(int id)
    {
        var _ocorrencia = _dbcontext.Ocorrencia.Find(id);
        if (_ocorrencia is null)
            throw new Exception();

        return _ocorrencia;
    }  

    public int Create(NewOcorrenciaInputModel ocorrencia)
    {
        var _ocorrencia = new Ocorrencia
        {
            Descricao = ocorrencia.Descricao,
            Situacao = ocorrencia.Situacao,
            DataHora = ocorrencia.DataHora,
            OrdemServicos = ocorrencia.OrdemServicoIds != null ? _dbcontext.OrdemServico.Where(os => ocorrencia.OrdemServicoIds.Contains(os.OrdemServicoID)).ToList() : null
        };
                    
        _dbcontext.Ocorrencia.Add(_ocorrencia);

        _dbcontext.SaveChanges();

        return _ocorrencia.OcorrenciaID;
    }

    public void Delete(int id)
    {
        var _ocorrencia = GetByDbId(id);

        _dbcontext.Ocorrencia.Remove(_ocorrencia);
        
        _dbcontext.SaveChanges();
    }

    public List<OcorrenciaViewModel> GetAll()
    {
        return _dbcontext.Ocorrencia.Select(ocorrencia => new OcorrenciaViewModel()
        {
            OcorrenciaID = ocorrencia.OcorrenciaID,
            Descricao = ocorrencia.Descricao,
            Situacao = ocorrencia.Situacao,
            DataHora = ocorrencia.DataHora,
            OrdemServicoIds = ocorrencia.OrdemServicos != null ? ocorrencia.OrdemServicos.Select(os => os.OrdemServicoID).ToList() : new List<int>()
        }).ToList();

    }

    public OcorrenciaViewModel? GetById(int id)
    {
        var ocorrencia = _dbcontext.Ocorrencia
            .Where(ocorrencia => ocorrencia.OcorrenciaID == id)
            .Select(ocorrencia => new OcorrenciaViewModel()
            {
                OcorrenciaID = ocorrencia.OcorrenciaID,
                Descricao = ocorrencia.Descricao,
                Situacao = ocorrencia.Situacao,
                DataHora = ocorrencia.DataHora,
                OrdemServicoIds = ocorrencia.OrdemServicos != null ? ocorrencia.OrdemServicos.Select(os => os.OrdemServicoID).ToList() : new List<int>()
            })
            .FirstOrDefault();

        return ocorrencia;
    }

    public void Update(int id, NewOcorrenciaInputModel ocorrencia)
    {
        var _ocorrencia = GetByDbId(id);

        _ocorrencia.Descricao = ocorrencia.Descricao;
        _ocorrencia.Situacao = ocorrencia.Situacao;
        _ocorrencia.DataHora = ocorrencia.DataHora;
        _ocorrencia.OrdemServicos = ocorrencia.OrdemServicoIds != null ? _dbcontext.OrdemServico.Where(os => ocorrencia.OrdemServicoIds.Contains(os.OrdemServicoID)).ToList() : null;

        _dbcontext.SaveChanges();
    }

}
