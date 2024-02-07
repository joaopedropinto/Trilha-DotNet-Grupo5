using TechMed.Application.Services.Interfaces;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Application.Services;
public abstract class BaseService
{
   protected readonly TechMedDbContext _context;
   protected BaseService(TechMedDbContext context){
      _context = context;
   }
}