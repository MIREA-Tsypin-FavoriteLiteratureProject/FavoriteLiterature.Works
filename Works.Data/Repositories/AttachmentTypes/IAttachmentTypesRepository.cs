using System.Linq.Expressions;
using Works.Data.Entities;

namespace Works.Data.Repositories.AttachmentTypes;

public interface IAttachmentTypesRepository
{
    AttachmentType? Get(Expression<Func<AttachmentType, bool>> expression);
    Task<AttachmentType?> GetAsync(Expression<Func<AttachmentType, bool>> expression, CancellationToken cancellationToken = default);
    Task<IEnumerable<AttachmentType>> GetAllAsync(Expression<Func<AttachmentType, bool>> expression, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Expression<Func<AttachmentType, bool>> expression, CancellationToken cancellationToken = default);

}