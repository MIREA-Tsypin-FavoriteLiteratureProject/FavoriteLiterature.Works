using Works.Data.Entities;
using Works.Data.Repositories.Common;

namespace Works.Data.Repositories.Authors;

public class AuthorsRepository : GenericRepository<Author>, IAuthorsRepository
{
    public AuthorsRepository(FavoriteLiteratureWorksDbContext dbContext) : base(dbContext)
    {
    }
}