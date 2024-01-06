using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        
    }
}
