using System.Linq.Expressions;
using FavoriteLiterature.Works.Data.Entities;

namespace FavoriteLiterature.Works.Data.Repositories.AttachmentTypes;

public interface IAttachmentTypesRepository
{
    AttachmentType? Get(Expression<Func<AttachmentType, bool>> expression);
    Task<AttachmentType?> GetAsync(Expression<Func<AttachmentType, bool>> expression, CancellationToken cancellationToken = default);
    Task<IEnumerable<AttachmentType>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Expression<Func<AttachmentType, bool>> expression, CancellationToken cancellationToken = default);
}