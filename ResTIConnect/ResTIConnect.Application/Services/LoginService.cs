using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Infra.Context;
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Infra.Auth;

namespace ResTIConnect.Application.Services;
public class LoginService : ILoginService
{
    private readonly ResTIConnectContext _dbcontext;
    private readonly IAuthService _authService; // Injete a interface IAuthService

    public LoginService(ResTIConnectContext dbcontext, IAuthService authService)
    {
        _dbcontext = dbcontext;
        _authService = authService;
    }

    public async Task<string?> AuthenticateAndGenerateToken(NewLoginInputModel login)
    {
        var usuario = await _dbcontext.Usuarios
            .Include(u => u.Endereco)
            .Include(u => u.Perfis)
            .FirstOrDefaultAsync(u => u.Email == login.Email && u.Senha == _authService.ComputeSha256Hash(login.Senha));

        if (usuario == null)
        {
            return null;
        }

        var token = _authService.GenerateJwtToken(usuario.Email, "user");

        return token;
    }
}
