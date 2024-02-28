using Microsoft.EntityFrameworkCore;
using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Infra.Auth;

namespace Ordem_Servico.Application.Services;
public class LoginService : ILoginService
{
    private readonly OrdemServicoContext _dbContext;
    private readonly IAuthService _authService;

    public LoginService(OrdemServicoContext dbContext, IAuthService authService)
    {
        _dbContext = dbContext;
        _authService = authService;
    }

    public async Task<ClienteViewModel?> Authenticate(NewLoginInputModel login)
    {
        try
        {
            var usuario = await _dbContext.Cliente
                .Where(u => u.Email == login.Email && u.Senha == _authService.ComputeSha256Hash(login.Senha))
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return null;
            }

            return new ClienteViewModel
            {
                ClienteID = usuario.ClienteID,
                Nome = usuario.Nome,
                Email = usuario.Email,
                CPF = usuario.CPF,
                CNPJ = usuario.CNPJ,
                Telefone = usuario.Telefone,
                Endereco = usuario.Endereco
            };
        } catch (Exception e) {
            return null;
        }
    }

}

