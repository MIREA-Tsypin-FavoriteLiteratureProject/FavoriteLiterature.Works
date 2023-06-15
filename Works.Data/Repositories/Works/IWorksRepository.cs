using System.Linq.Expressions;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Data.Repositories.Common;

namespace FavoriteLiterature.Works.Data.Repositories.Works;

public interface IWorksRepository  : IGenericRepository<Work>
{
    Task<IEnumerable<Work>> GetAllWorksWithAuthorsAndGenresAsync(int skip, int take, CancellationToken cancellationToken = default);

    Task<Work?> GetFullWork(Expression<Func<Work, bool>> expression, CancellationToken cancellationToken = default);
}