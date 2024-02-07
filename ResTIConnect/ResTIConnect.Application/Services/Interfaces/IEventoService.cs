namespace ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
public interface IEventoService
{
    public List<EventoViewModel> GetAll();
    public EventoViewModel? GetById(int id);
    public int Create(NewEventoInputModel evento);
    public void Update(int id, NewEventoInputModel evento);
    public void Delete (int id);
}
