using Trilha_DotNet_Grupo5.Domain.Common;

namespace Trilha_DotNet_Grupo5.Domain.Common;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> Get(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}
