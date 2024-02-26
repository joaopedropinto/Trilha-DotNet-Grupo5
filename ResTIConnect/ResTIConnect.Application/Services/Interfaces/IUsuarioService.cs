namespace ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
public interface IUsuarioService
{
    public List<UsuarioViewModel> GetAll();
    public UsuarioViewModel? GetById(int id);
    public Task<PerfilViewModel?> GetProfileById(int id);
    public List<UsuarioViewModel> GetUsersByUF(string uf);
    public int Create(NewUsuarioInputModel usuario);
    public void Update(int id, NewUsuarioInputModel usuario);
    public void Delete(int id);
}
