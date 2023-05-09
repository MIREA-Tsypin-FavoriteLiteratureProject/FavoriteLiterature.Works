namespace FavoriteLiterature.Works.Domain.Genres.Responses.Commands;

public class DeleteGenreResponse
{
    public Guid Id { get; }

    public DeleteGenreResponse(Guid id)
        => Id = id;
}