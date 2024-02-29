using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.Services.Interfaces;
using Ordem_Servico.Application.ViewModels;
using Ordem_Servico.Domain.Entities;
using Ordem_Servico.Infra.Auth;
using System.Linq;
using System.Threading.Tasks;

namespace Ordem_Servico.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly OrdemServicoContext _dbContext;
        private readonly IAuthService _authService;

        public LoginService(OrdemServicoContext dbContext, IAuthService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }

        public async Task<string?> Authenticate(NewLoginInputModel login)
        {
            var cliente = _dbContext.Cliente
                .Where(c => c.Email == login.Email)
                .FirstOrDefault();

            if (cliente == null)
            {
                return null;
            }

            bool isPasswordValid = _authService.ComputeSha256Hash(login.Senha) == cliente.Senha;

            if (!isPasswordValid)
            {
                return null;
            }

            var token = _authService.GenerateJwtToken(cliente.Email, "Admin");

            return token;
        }
    }
}
