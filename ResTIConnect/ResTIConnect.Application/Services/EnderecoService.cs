using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Context;
//using ResTIConnect.Domain.Exceptions;

namespace ResTIConnect.Application.Services;
public class EnderecoService : IEnderecoService
{
    private readonly ResTIConnectContext _dbcontext;
    public EnderecoService(ResTIConnectContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    private Endereco GetById(int id)
    {
        var _endereco = _dbcontext.Enderecos.Find(id);
        if (_endereco is null)
        {
            throw new Exception();//fazer as exceptions pra adicionar aqui
        }
        return _endereco;
    }

    public int Create(NewEnderecoInputModel endereco)
    {
        var _endereco = new Endereco
        {
            Logradouro = endereco.Logradouro,
            Numero = endereco.Numero,
            Cidade = endereco.Cidade,
            Complemento = endereco.Complemento,
            Bairro = endereco.Bairro,
            Estado = endereco.Estado,
            Cep = endereco.Cep,
            Pais = endereco.Pais

        };
        _dbcontext.Enderecos.Add(_endereco);
        _dbcontext.SaveChanges();
        return _endereco.EnderecoId;
    }

    public void Delete(int id)
    {
        var _endereco = GetById(id);
        _dbcontext.Enderecos.Remove(_endereco);
        _dbcontext.SaveChanges();
    }

    public List<EnderecoViewModel> GetAll()
    {
        var _enderecos = _dbcontext.Enderecos.ToList();
        return _enderecos.Select(c => new EnderecoViewModel()
        {
            EnderecoId = c.EnderecoId,
            Logradouro = c.Logradouro,
            Numero = c.Numero,
            Cidade = c.Cidade,
            Complemento = c.Complemento,
            Bairro = c.Bairro,
            Estado = c.Estado,
            Cep = c.Cep,
            Pais = c.Pais
        }).ToList();
    }
    // public EnderecoViewModel? GetById(int id){

    //     var _endereco = GetByDbId(id);

    //     return new EnderecoViewModel(){
    //         EnderecoId = _endereco.EnderecoId,
    //         Numero = _endereco.Numero,
    //         Cidade = _endereco.Cidade,
    //         Complemento = _endereco.Complemento,
    //         Bairro = _endereco.Bairro,
    //         Estado = _endereco.Estado,
    //         Cep = _endereco.Cep,
    //         Pais = _endereco.Pais
    //     };
    // }
    // precisa adicionar o GetByDbId pra poder usar esse método

    // public void Update(int id, NewEnderecoInputModel _endereco){
    //     var _endereco = GetByBdId(id);
    //     _endereco.Logradouro = _endereco.Logradouro;
    //     _dbcontext.Enderecos.Update(_endereco);
    //     _dbcontext.SaveChanges();
    // }
}
