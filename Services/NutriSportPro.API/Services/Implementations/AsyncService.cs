using NutriSportPro.API.Services.Contratcs;
using System.Linq.Expressions;

namespace NutriSportPro.API.Services.Implementations;

public class AsyncService<T> : IAsyncService<T> where T : class
{
    protected readonly ApplicationDbContext dbContext;

    public AsyncService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<T?> GetByIdAsync(int id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().ToListAsync();
    }
    public async Task<T> AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }
    public async Task<bool> UpdateAsync(T entity)
    {
        dbContext.Set<T>().Update(entity);
        return await dbContext.SaveChangesAsync() > 0;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null) return false;
        dbContext.Set<T>().Remove(entity);
        return await dbContext.SaveChangesAsync() > 0;
    }
    public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate)
    {
        return await Task.FromResult(dbContext.Set<T>().Where(predicate));
    }
}
