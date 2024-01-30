using TechAdvocacia.Application.Services.Interfaces;
using TechAdvocacia.Infrastructure.Persistence;

namespace TechAdvocacia.Application.Services;
public abstract class BaseService
{
   protected readonly TechAdvocaciaDbContext _context;
   protected BaseService(TechAdvocaciaDbContext context){
      _context = context;
   }
}
