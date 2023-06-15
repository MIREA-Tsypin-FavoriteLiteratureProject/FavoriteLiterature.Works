using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Data.Repositories.Common;

namespace FavoriteLiterature.Works.Data.Repositories.Attachments;

public class AttachmentsRepository : GenericRepository<Attachment>, IAttachmentsRepository
{
    public AttachmentsRepository(FavoriteLiteratureWorksDbContext dbContext) : base(dbContext)
    {
    }
}