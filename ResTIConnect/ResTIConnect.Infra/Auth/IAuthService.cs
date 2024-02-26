namespace ResTIConnect.Infra.Auth;
public interface IAuthService
{
    string ComputeSha256Hash(string pass);
}
