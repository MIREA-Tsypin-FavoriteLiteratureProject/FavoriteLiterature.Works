using System.Linq.Expressions;
using FavoriteLiterature.Works.Data.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Works.Data.Repositories.Common;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly FavoriteLiteratureWorksDbContext _dbContext;
    protected readonly DbSet<T> EntitySet;

    protected GenericRepository(FavoriteLiteratureWorksDbContext dbContext)
    {
        _dbContext = dbContext;
        EntitySet = _dbContext.Set<T>();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) 
        => await EntitySet.FirstOrDefaultAsync(expression, cancellationToken);

    public async Task<IEnumerable<T>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default)
        => await EntitySet.Skip(skip).Take(take).ToListAsync(cancellationToken);

    public void Add(T entity) 
        => _dbContext.Add(entity);

    public void Update(T entity) 
        => _dbContext.Update(entity);

    public void Remove(T entity) 
        => _dbContext.Remove(entity);

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) 
        => await EntitySet.AnyAsync(expression, cancellationToken);
}