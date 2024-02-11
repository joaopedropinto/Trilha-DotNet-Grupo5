using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.Application.Services.Interfaces;

public interface IPecaService
{
    public List<PecaViewModel> GetAll();
    public PecaViewModel? GetById(int id);
    public int Create(NewPecaInputModel peca);
    public void Update(int id, NewPecaInputModel peca);
    public void Delete(int id);
}
