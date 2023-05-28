using System.Linq.Expressions;
using FavoriteLiterature.Works.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FavoriteLiterature.Works.Data.Repositories.AttachmentTypes;

public class AttachmentTypesRepository : IAttachmentTypesRepository
{
    private readonly FavoriteLiteratureWorksDbContext _dbContext;

    public AttachmentTypesRepository(FavoriteLiteratureWorksDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public AttachmentType? Get(Expression<Func<AttachmentType, bool>> expression)
        => _dbContext.AttachmentTypes.FirstOrDefault(expression);

    public async Task<AttachmentType?> GetAsync(Expression<Func<AttachmentType, bool>> expression, CancellationToken cancellationToken = default) 
        => await _dbContext.AttachmentTypes.FirstOrDefaultAsync(expression, cancellationToken);

    public async Task<IEnumerable<AttachmentType>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default)
        => await _dbContext.AttachmentTypes.Skip(skip).Take(take).ToListAsync(cancellationToken);

    public async Task<bool> ExistsAsync(Expression<Func<AttachmentType, bool>> expression, CancellationToken cancellationToken = default)
        => await _dbContext.AttachmentTypes.AnyAsync(expression, cancellationToken);
}