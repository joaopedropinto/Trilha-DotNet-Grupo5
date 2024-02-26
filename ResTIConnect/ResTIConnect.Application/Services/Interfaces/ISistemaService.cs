namespace ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
public interface ISistemaService
{
    public List<SistemaViewModel> GetAll();
    public SistemaViewModel? GetById(int id);
    public List<SistemaViewModel> GetSistemasByUserId(int userId);
    public List<SistemaViewModel> GetSystemsByEventFromDate(string type, DateTimeOffset fromDate);
    public int Create(NewSistemaInputModel sistema);
    public void Update(int id, NewSistemaInputModel sistema);
    public void Delete(int id);
}
