namespace Ordem_Servico.Infra.Auth;
public interface IAuthService
{
    string ComputeSha256Hash(string pass);
}