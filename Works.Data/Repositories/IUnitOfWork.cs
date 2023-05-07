using FavoriteLiterature.Works.Data.Repositories.Attachments;
using FavoriteLiterature.Works.Data.Repositories.AttachmentTypes;
using FavoriteLiterature.Works.Data.Repositories.Authors;
using FavoriteLiterature.Works.Data.Repositories.Genres;
using Works.Data.Repositories.Works;

namespace FavoriteLiterature.Works.Data.Repositories;

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