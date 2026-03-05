using Microsoft.EntityFrameworkCore;
using StudentPortalMVC.Data;
using StudentPortalMVC.Repositories.Interfaces;
using System.Linq.Expressions;

namespace StudentPortalMVC.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly StudentPortalDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(StudentPortalDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IQueryable<T>>? include = null)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
            query = query.Where(filter);

        if (include != null)
            query = include(query);

        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task InsertAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
{
    _context.Entry(entity).State = EntityState.Modified;
}

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}