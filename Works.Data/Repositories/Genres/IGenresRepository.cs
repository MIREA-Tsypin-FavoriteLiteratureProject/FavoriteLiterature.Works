using System.Linq.Expressions;
using FavoriteLiterature.Works.Data.Entities;

namespace FavoriteLiterature.Works.Data.Repositories.Genres;

public interface IGenresRepository
{
    Genre? Get(Expression<Func<Genre, bool>> expression);
    Task<Genre?> GetAsync(Expression<Func<Genre, bool>> expression, CancellationToken cancellationToken = default);
    Task<IEnumerable<Genre>> GetAllAsync(Expression<Func<Genre, bool>> expression, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Expression<Func<Genre, bool>> expression, CancellationToken cancellationToken = default);
}