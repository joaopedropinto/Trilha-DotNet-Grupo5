using Microsoft.EntityFrameworkCore;
using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.Application.Services;
public class LoginService : ILoginService
{
    private readonly OrdemServicoContext _dbContext;

    public LoginService(OrdemServicoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UsuarioViewModel?> Authenticate(NewLoginInputModel login)
    {
        var usuario = await _dbContext.Usuario
            .Where(u => u.Email == login.Email && u.Senha == login.Senha)
            .Select(u => new UsuarioViewModel
            {
                UsuarioID = u.UsuarioID,
                Nome = u.Nome,
                Email = u.Email
            })
            .FirstOrDefaultAsync();

        return usuario;
    }

}

