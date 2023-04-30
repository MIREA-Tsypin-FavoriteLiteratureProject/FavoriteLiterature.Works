using Works.Data.Entities;
using Works.Data.Repositories.Common;

namespace Works.Data.Repositories.Attachments;

public class AttachmentsRepository : GenericRepository<Attachment>, IAttachmentsRepository
{
    public AttachmentsRepository(FavoriteLiteratureWorksDbContext dbContext) : base(dbContext)
    {
    }
}