using FavoriteLiterature.Works.Data;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Data.Repositories.Common;

namespace Works.Data.Repositories.Works;

public class WorksRepository : GenericRepository<Work>, IWorksRepository
{
    public WorksRepository(FavoriteLiteratureWorksDbContext dbContext) : base(dbContext)
    {
    }
}