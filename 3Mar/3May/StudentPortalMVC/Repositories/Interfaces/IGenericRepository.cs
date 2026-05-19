using System.Linq.Expressions;

namespace StudentPortalMVC.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null);

    Task<T?> GetByIdAsync(object id);

    Task InsertAsync(T entity);

    void Update(T entity);

    void Delete(T entity);

    Task SaveAsync();
}