namespace ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
public interface ILogService
{
    public List<LogViewModel> GetAll();
    public LogViewModel? GetById(int id);
    public int Create(NewLogInputModel log);
    public void Update(int id, NewLogInputModel log);
    public void Delete (int id);
}
