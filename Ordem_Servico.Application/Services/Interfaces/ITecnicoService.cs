using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.Application.Services.Interfaces;
public interface ITecnicoService
{
    public List<TecnicoViewModel> GetAll();
    public TecnicoViewModel? GetById(int id);
    public int Create(NewTecnicoInputModel tecnico);
    public void Update(int id, NewTecnicoInputModel tecnico);
    public void Delete(int id);
}
