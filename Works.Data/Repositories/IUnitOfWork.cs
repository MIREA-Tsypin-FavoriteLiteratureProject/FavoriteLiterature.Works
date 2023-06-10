using FavoriteLiterature.Works.Data.Repositories.Attachments;
using FavoriteLiterature.Works.Data.Repositories.Authors;
using FavoriteLiterature.Works.Data.Repositories.Genres;
using FavoriteLiterature.Works.Data.Repositories.Works;

namespace FavoriteLiterature.Works.Data.Repositories;

public interface IUnitOfWork
{
    IAttachmentsRepository AttachmentsRepository { get; }
    IAuthorsRepository AuthorsRepository { get; }
    IGenresRepository GenresRepository { get; }
    IWorksRepository WorksRepository { get; }
    
    void Commit();
    Task CommitAsync();
    Task BeginTransactionAsync(IEnumerable<Action> actions);
    void Rollback();
    Task RollbackAsync();
}