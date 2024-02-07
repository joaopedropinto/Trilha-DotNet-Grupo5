namespace ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
public interface IPerfilService
{
    public List<PerfilViewModel> GetAll();
    public PerfilViewModel? GetById(int id);
    public int Create(NewPerfilInputModel perfil);
    public void Update(int id, NewPerfilInputModel perfil);
    public void Delete (int id);
}
