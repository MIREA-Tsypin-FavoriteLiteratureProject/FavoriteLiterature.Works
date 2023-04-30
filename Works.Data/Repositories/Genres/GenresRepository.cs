using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Works.Data.Entities;

namespace Works.Data.Repositories.Genres;

public class GenresRepository : IGenresRepository
{
    private readonly FavoriteLiteratureWorksDbContext _dbContext;

    public GenresRepository(FavoriteLiteratureWorksDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Genre? Get(Expression<Func<Genre, bool>> expression)
        => _dbContext.Genres.FirstOrDefault(expression);

    public async Task<Genre?> GetAsync(Expression<Func<Genre, bool>> expression, CancellationToken cancellationToken = default) 
        => await _dbContext.Genres.FirstOrDefaultAsync(expression, cancellationToken);

    public async Task<IEnumerable<Genre>> GetAllAsync(Expression<Func<Genre, bool>> expression, CancellationToken cancellationToken = default)
        => await _dbContext.Genres.Where(expression).ToListAsync(cancellationToken);

    public async Task<bool> ExistsAsync(Expression<Func<Genre, bool>> expression, CancellationToken cancellationToken = default)
        => await _dbContext.Genres.AnyAsync(expression, cancellationToken);
}