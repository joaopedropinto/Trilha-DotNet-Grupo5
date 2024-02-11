using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.Application.Services.Interfaces;

public interface IFinalizacaoService
{
    public List<FinalizacaoViewModel> GetAll();
    public FinalizacaoViewModel? GetById(int id);
    public int Create(NewFinalizacaoInputModel finalizacao);
    public void Update(int id, NewFinalizacaoInputModel finalizacao);
    public void Delete(int id);
}
