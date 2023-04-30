using Works.Data.Repositories.Attachments;
using Works.Data.Repositories.AttachmentTypes;
using Works.Data.Repositories.Authors;
using Works.Data.Repositories.Genres;
using Works.Data.Repositories.Works;

namespace Works.Data.Repositories;

public interface IUnitOfWork
{
    IAttachmentsRepository AttachmentsRepository { get; }
    IAttachmentTypesRepository AttachmentTypesRepository { get; }
    IAuthorsRepository AuthorsRepository { get; }
    IGenresRepository GenresRepository { get; }
    IWorksRepository WorksRepository { get; }
    
    void Commit();
    Task CommitAsync();
    Task BeginTransactionAsync(IEnumerable<Action> actions);
    void Rollback();
    Task RollbackAsync();
}