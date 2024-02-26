using System.Linq.Expressions;
using ResTIConnect.Infra.Context;

namespace ResTIConnect.EFCore;

public class CrudService
{
    private readonly ResTIConnectContext context;

    public CrudService(ResTIConnectContext dbContext)
    {
        context = dbContext;
    }

    public void Create<T>(T entity) where T : class
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public IEnumerable<T> GetAll<T>() where T : class
    {
        return context.Set<T>().ToList();
    }

    public void Update<T>(T entity) where T : class
    {
        context.Set<T>().Update(entity);
        context.SaveChanges();
    }

    public void Delete<T>(T entity) where T : class
    {
        context.Set<T>().Remove(entity);
        context.SaveChanges();
    }

    public T? GetByFilter<T>(Expression<Func<T, bool>> filter) where T : class
    {
        return context.Set<T>().FirstOrDefault(filter);
    }
}