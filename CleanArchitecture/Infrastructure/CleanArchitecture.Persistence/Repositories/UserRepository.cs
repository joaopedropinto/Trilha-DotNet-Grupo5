using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
        {
            // Use o operador ?? para fornecer um valor padrão caso o resultado seja nulo
            return await Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken) ?? throw new InvalidOperationException($"Usuário com o e-mail '{email}' não encontrado.");
        }
    }
}
