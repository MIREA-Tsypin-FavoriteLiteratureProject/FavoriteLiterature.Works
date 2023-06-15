using System.Linq.Expressions;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Data.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Works.Data.Repositories.Works;

public class WorksRepository : GenericRepository<Work>, IWorksRepository
{
    public WorksRepository(FavoriteLiteratureWorksDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Work>> GetAllWorksWithAuthorsAndGenresAsync(int skip, int take, CancellationToken cancellationToken = default) 
        => await EntitySet
            .Include(x => x.Authors)
            .Include(x => x.Genres)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);

    public async Task<Work?> GetFullWork(Expression<Func<Work, bool>> expression, CancellationToken cancellationToken = default) 
        => await EntitySet
            .Include(x => x.Authors)
            .Include(x => x.Genres)
            .Include(x => x.Attachments)
            .FirstOrDefaultAsync(expression, cancellationToken);
}