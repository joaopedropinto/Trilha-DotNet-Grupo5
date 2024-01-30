using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Core.Entities;
using TechAdvocacia.Infrastructure.Persistence;
using TechAdvocacia.Core.Exceptions;

namespace TechAdvocacia.Application.Services;
public class ClientService : IClientService
{
    private readonly TechAdvocaciaDbContext _dbcontext;
    public ClientService(TechAdvocaciaDbContext dbcontext){
        _dbcontext = dbcontext;
    }
    private Client GetByDbId(int id){
        var _client = _dbcontext.Clients.Find(id);
        if (_client is null)
            throw new ClientNotFoundException();
        
        return _client;
    }
    public int Create(NewClientInputModel client)
    {
        var _client = new Client
        {
            Name = client.Name
        };
        _dbcontext.Clients.Add(_client);

        _dbcontext.SaveChanges();

        return _client.ClientId;
    }

    public void Delete(int id)
    {
        var _client = GetByDbId(id);

        _dbcontext.Clients.Remove(_client);

        _dbcontext.SaveChanges();
    }

    public List<ClientViewModel> GetAll()
    {
        var _clients = _dbcontext.Clients.ToList();

        return _clients.Select(c => new ClientViewModel(){
            ClientId = c.ClientId,
            Name = c.Name
        }).ToList();
    }

    public ClientViewModel? GetById(int id)
    {
        var _client = GetByDbId(id);

        return new ClientViewModel(){
            ClientId = _client.ClientId,
            Name = _client.Name
        };
    }

    public void Update(int id, NewClientInputModel client)
    {
        var _client = GetByDbId(id);

        _client.Name = client.Name;

        _dbcontext.Clients.Update(_client);

        _dbcontext.SaveChanges();
    }
}