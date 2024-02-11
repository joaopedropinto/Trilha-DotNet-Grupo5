using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.Application.Services.Interfaces;

public interface IOcorrenciaService
{
    public List<OcorrenciaViewModel> GetAll();
    public OcorrenciaViewModel? GetById(int id);
    public int Create(NewOcorrenciaInputModel ocorrencia);
    public void Update(int id, NewOcorrenciaInputModel ocorrencia);
    public void Delete(int id);
}
