using Ordem_Servico.Application.InputModels;
using Ordem_Servico.Application.ViewModels;

namespace Ordem_Servico.Application.Services.Interfaces;
public interface ILoginService
{
    Task<string?> Authenticate(NewLoginInputModel login);
}