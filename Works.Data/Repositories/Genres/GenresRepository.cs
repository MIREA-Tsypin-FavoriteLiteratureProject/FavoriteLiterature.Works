using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Data.Repositories.Common;

namespace FavoriteLiterature.Works.Data.Repositories.Genres;

public class GenresRepository : GenericRepository<Genre>, IGenresRepository
{
    public GenresRepository(FavoriteLiteratureWorksDbContext dbContext) : base(dbContext)
    {
    }
}