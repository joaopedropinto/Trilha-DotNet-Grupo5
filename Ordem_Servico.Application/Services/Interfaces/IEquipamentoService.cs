using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.Application.Services.Interfaces;
public interface IEquipamentoService
{
    public List<EquipamentoViewModel> GetAll();
    public EquipamentoViewModel? GetById(int id);
    public int Create(NewEquipamentoInputModel equipamento);
    public void Update(int id, NewEquipamentoInputModel equipamento);
    public void Delete(int id);
}
