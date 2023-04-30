﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Works.Data.Entities.Abstract;

namespace Works.Data.Repositories.Common;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly FavoriteLiteratureWorksDbContext _dbContext;
    private readonly DbSet<T> _entitySet;

    protected GenericRepository(FavoriteLiteratureWorksDbContext dbContext)
    {
        _dbContext = dbContext;
        _entitySet = _dbContext.Set<T>();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) 
        => await _entitySet.FirstOrDefaultAsync(expression, cancellationToken);

    public async Task<IEnumerable<T>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default)
        => await _entitySet.Skip(skip).Take(take).ToListAsync(cancellationToken);

    public void Add(T entity) 
        => _dbContext.Add(entity);

    public void Update(T entity) 
        => _dbContext.Update(entity);

    public void Remove(T entity) 
        => _dbContext.Remove(entity);

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) 
        => await _entitySet.AnyAsync(expression, cancellationToken);
}