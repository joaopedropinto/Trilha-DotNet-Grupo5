namespace TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;

public interface IClientService{
    public List <ClientViewModel> GetAll();
    public ClientViewModel? GetById(int id);
    public int Create(NewClientInputModel lawyer);
    public void Update(int id, NewClientInputModel lawyer);
    public void Delete (int id);
}