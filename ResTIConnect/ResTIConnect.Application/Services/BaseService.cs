using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Infra.Context;
namespace ResTIConnect.Application.Services;
public abstract class BaseService
{
   protected readonly ResTIConnectContext _context;
   protected BaseService(ResTIConnectContext context){
      _context = context;
   }
}