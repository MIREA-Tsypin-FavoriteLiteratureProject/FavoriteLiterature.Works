using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Data.Repositories.Common;
using Works.Data;

namespace FavoriteLiterature.Works.Data.Repositories.Authors;

public class AuthorsRepository : GenericRepository<Author>, IAuthorsRepository
{
    public AuthorsRepository(FavoriteLiteratureWorksDbContext dbContext) : base(dbContext)
    {
    }
}