namespace Ordem_Servico.Application.Services;

public abstract class BaseService
{
    protected readonly OrdemServicoContext _context;
    protected BaseService(OrdemServicoContext context) {
        _context = context;
    }
}
