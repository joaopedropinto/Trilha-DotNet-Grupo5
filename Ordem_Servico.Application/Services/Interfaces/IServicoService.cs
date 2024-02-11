using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.Application.Services.Interfaces;
public interface IServicoService
{
    public List<ServicoViewModel> GetAll();
    public ServicoViewModel? GetById(int id);
    public int Create(NewServicoInputModel servico);
    public void Update(int id, NewServicoInputModel servico);
    public void Delete(int id);
}
