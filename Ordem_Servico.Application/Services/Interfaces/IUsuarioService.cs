using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.Application.Services.Interfaces;
public interface IUsuarioService
{
    List<UsuarioViewModel> GetAll();
    UsuarioViewModel? GetById(int id);
    int Create(NewUsuarioInputModel usuario);
    void Update(int id, NewUsuarioInputModel usuario);
    void Delete(int id);
}