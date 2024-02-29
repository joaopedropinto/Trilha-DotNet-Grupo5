using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


namespace Ordem_Servico.Infra.Auth;
public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string ComputeSha256Hash(string? pass)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash;
        }
    }

    public string GenerateJwtToken(string? email, string? role)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = _configuration["Jwt:Key"];
        //cria uma chave utilizando criptografia simétrica
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        //cria as credenciais do token
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
         new Claim("userName", email),
         new Claim(ClaimTypes.Role, role)
      };

        var token = new JwtSecurityToken(
           issuer: issuer,
           audience: audience, 
           claims: claims,
           expires: DateTime.Now.AddMinutes(30), 
           signingCredentials: credentials); 


        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }
}