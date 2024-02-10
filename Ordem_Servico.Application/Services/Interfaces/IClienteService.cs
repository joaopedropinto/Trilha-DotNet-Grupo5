using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.Application.Services.Interfaces;
public interface IClienteService
{
    public List<ClienteViewModel> GetAll();
    public ClienteViewModel? GetById(int id);
    public int Create(NewClienteInputModel cliente);
    public void Update(int id, NewClienteInputModel cliente);
    public void Delete(int id);
}
