using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Domain;

namespace Ordem_Servico.Application.Services;

public class ClienteService : IClienteService
{
    private readonly OrdemServicoContext _dbcontext;
    public ClienteService(OrdemServicoContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    private Cliente GetByDbId(int id)
    {
        var _cliente = _dbcontext.Cliente.Find(id);
        if (_cliente is null)
            throw new Exception();

        return _cliente;
    }
    public int Create(NewClienteInputModel cliente)
    {
        var _cliente = new Cliente
        {
            Nome = cliente.Nome,
            CPF = cliente.CPF,
            CNPJ = cliente.CNPJ,
            Telefone = cliente.Telefone,
            Email = cliente.Email,
            Endereco = cliente.Endereco
        };
        _dbcontext.Cliente.Add(_cliente);

        _dbcontext.SaveChanges();

        return _cliente.ClienteID;
    }

    public void Delete(int id)
    {
        var _cliente = GetByDbId(id);

        _dbcontext.Cliente.Remove(_cliente);

        _dbcontext.SaveChanges();
    }

    public List<ClienteViewModel> GetAll()
    {
        var _clientes = _dbcontext.Cliente.ToList();

        return _clientes.Select(cliente => new ClienteViewModel()
        {
            ClienteID = cliente.ClienteID,
            Nome = cliente.Nome,
            CPF = cliente.CPF,
            CNPJ = cliente.CNPJ,
            Telefone = cliente.Telefone,
            Email = cliente.Email,
            Endereco = cliente.Endereco
        }).ToList();
    }

    public ClienteViewModel? GetById(int id)
    {
        var _cliente = GetByDbId(id);

        return new ClienteViewModel()
        {
            ClienteID = _cliente.ClienteID,
            Nome = _cliente.Nome,
            CPF = _cliente.CPF,
            CNPJ = _cliente.CNPJ,
            Telefone = _cliente.Telefone,
            Email = _cliente.Email,
            Endereco = _cliente.Endereco
        };
    }

    public void Update(int id, NewClienteInputModel cliente)
    {
        var _cliente = GetByDbId(id);

        _cliente.Nome = cliente.Nome;
        _cliente.CPF = cliente.CPF;
        _cliente.CNPJ = cliente.CNPJ;
        _cliente.Telefone = cliente.Telefone;
        _cliente.Email = cliente.Email;
        _cliente.Endereco = cliente.Endereco;

        _dbcontext.Cliente.Update(_cliente);

        _dbcontext.SaveChanges();
    }
}
