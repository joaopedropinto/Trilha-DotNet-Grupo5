using Ordem_Servico.Application.InputModels;

namespace Ordem_Servico.Application.Services.Interfaces;
public interface IOrdemServicoService
{
    public List<OrdemServicoVie
    wModel> GetAll();
    public OrdemServicoViewModel? GetById(int id);
    public int Create(NewOrdemServicoInputModel ordemServico);
    public void Update(int id, NewOrdemServicoInputModel ordemServico);
    public void Delete(int id);
}
