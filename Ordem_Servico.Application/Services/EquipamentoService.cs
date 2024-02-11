using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Domain.Entities;

namespace Ordem_Servico.Application.Services;

public class EquipamentoService : IEquipamentoService
{
    private readonly OrdemServicoContext _dbcontext;
    public EquipamentoService(OrdemServicoContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    private Equipamento GetByDbId(int id)
    {
        var _equipamento = _dbcontext.Equipamento.Find(id);
        if (_equipamento is null)
            throw new Exception();

        return _equipamento;
    }
    public int Create(NewEquipamentoInputModel equipamento)
    {
        var _equipamento = new Equipamento
        {
            Tipo = equipamento.Tipo,
            Marca = equipamento.Marca,
            Modelo = equipamento.Modelo,
            DadosAdicionais = equipamento.DadosAdicionais,
            DefeitoDeclarado = equipamento.DefeitoDeclarado,
            Solucao = equipamento.Solucao
        };
        _dbcontext.Equipamento.Add(_equipamento);

        _dbcontext.SaveChanges();

        return _equipamento.EquipamentoID;
    }

    public void Delete(int id)
    {
        var _equipamento = GetByDbId(id);

        _dbcontext.Equipamento.Remove(_equipamento);

        _dbcontext.SaveChanges();
    }

    public List<EquipamentoViewModel> GetAll()
    {
        var _equipamentos = _dbcontext.Equipamento.ToList();

        return _equipamentos.Select(equipamento => new EquipamentoViewModel()
        {
            EquipamentoID = equipamento.EquipamentoID,
            Tipo = equipamento.Tipo,
            Marca = equipamento.Marca,
            Modelo = equipamento.Modelo,
            DadosAdicionais = equipamento.DadosAdicionais,
            DefeitoDeclarado = equipamento.DefeitoDeclarado,
            Solucao = equipamento.Solucao
        }).ToList();
    }

    public EquipamentoViewModel? GetById(int id)
    {
        var _equipamento = GetByDbId(id);

        return new EquipamentoViewModel()
        {
            EquipamentoID = _equipamento.EquipamentoID,
            Tipo = _equipamento.Tipo,
            Marca = _equipamento.Marca,
            Modelo = _equipamento.Modelo,
            DadosAdicionais = _equipamento.DadosAdicionais,
            DefeitoDeclarado = _equipamento.DefeitoDeclarado,
            Solucao = _equipamento.Solucao
        };
    }

    public void Update(int id, NewEquipamentoInputModel equipamento)
    {
        var _equipamento = GetByDbId(id);

        _equipamento.Tipo = equipamento.Tipo;
        _equipamento.Marca = equipamento.Marca;
        _equipamento.Modelo = equipamento.Modelo;
        _equipamento.DadosAdicionais = equipamento.DadosAdicionais;
        _equipamento.DefeitoDeclarado = equipamento.DefeitoDeclarado;
        _equipamento.Solucao = equipamento.Solucao;

        _dbcontext.Equipamento.Update(_equipamento);

        _dbcontext.SaveChanges();
    }
}
