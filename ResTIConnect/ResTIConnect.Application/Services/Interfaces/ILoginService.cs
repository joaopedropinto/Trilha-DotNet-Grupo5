namespace ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.ViewModels;
using System.Threading.Tasks;

public interface ILoginService
{
    Task<UsuarioViewModel?> Authenticate(NewLoginInputModel login);
}

