using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Ordem_Servico.Domain.Entities;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ordem_Servico.WebAPI.Middleware;

public class AuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly OrdemServicoContext _context;

    public AuthorizationMiddleware(RequestDelegate next, OrdemServicoContext context)
    {
        _next = next;
        _context = context;
    }

    public async Task Invoke(HttpContext context)
    {
        // Verificar se o usuário está autenticado
        if (!context.User.Identity.IsAuthenticated)
        {
            // Se o usuário não estiver autenticado, negar acesso
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Acesso não autorizado. Faça login para continuar.");
            return;
        }

        // Verificar se o usuário está associado a um técnico no banco de dados
        var userEmail = context.User.FindFirst(ClaimTypes.Email)?.Value;
        var isTechnician = await _context.Tecnico.AnyAsync(t => t.Email == userEmail);

        // Se o usuário for um técnico, ele tem acesso como administrador
        if (isTechnician)
        {
            await _next(context);
            return;
        }

        // Se o usuário não for um técnico, ele não tem acesso especial
        context.Response.StatusCode = 403; // Forbidden
        await context.Response.WriteAsync("Acesso negado. Você não tem permissão para acessar este recurso.");
    }
}
