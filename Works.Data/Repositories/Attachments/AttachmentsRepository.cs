using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Data.Repositories.Common;
using Works.Data;

namespace FavoriteLiterature.Works.Data.Repositories.Attachments;

public class AttachmentsRepository : GenericRepository<Attachment>, IAttachmentsRepository
{
    public AttachmentsRepository(FavoriteLiteratureWorksDbContext dbContext) : base(dbContext)
    {
    }
}