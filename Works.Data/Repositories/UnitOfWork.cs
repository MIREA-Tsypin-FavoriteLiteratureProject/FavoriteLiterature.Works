using Works.Data.Repositories.Attachments;
using Works.Data.Repositories.AttachmentTypes;
using Works.Data.Repositories.Authors;
using Works.Data.Repositories.Genres;
using Works.Data.Repositories.Works;

namespace Works.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly FavoriteLiteratureWorksDbContext _dbContext;

    public IAttachmentsRepository AttachmentsRepository { get; }
    public IAttachmentTypesRepository AttachmentTypesRepository { get; }
    public IAuthorsRepository AuthorsRepository { get; }
    public IGenresRepository GenresRepository { get; }
    public IWorksRepository WorksRepository { get; }

    public UnitOfWork(FavoriteLiteratureWorksDbContext dbContext, IAttachmentsRepository attachmentsRepository,
        IAttachmentTypesRepository attachmentTypesRepository, IAuthorsRepository authorsRepository,
        IGenresRepository genresRepository, IWorksRepository worksRepository)
    {
        _dbContext = dbContext;
        AttachmentsRepository = attachmentsRepository;
        AttachmentTypesRepository = attachmentTypesRepository;
        AuthorsRepository = authorsRepository;
        GenresRepository = genresRepository;
        WorksRepository = worksRepository;
    }

    public void Commit()
        => _dbContext.SaveChanges();

    public async Task CommitAsync()
        => await _dbContext.SaveChangesAsync();

    public async Task BeginTransactionAsync(IEnumerable<Action> actions)
    {
        try
        {
            foreach (var action in actions)
            {
                action();
            }
            await CommitAsync();
        }
        catch (Exception)
        {
            await RollbackAsync();
            throw;
        }
    }

    public void Rollback()
        => _dbContext.Dispose();

    public async Task RollbackAsync()
        => await _dbContext.DisposeAsync();
}