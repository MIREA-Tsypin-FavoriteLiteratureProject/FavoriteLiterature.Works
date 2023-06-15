namespace FavoriteLiterature.Works.Domain.Genres.Responses.Commands;

public class UpdateGenreResponse
{
    public Guid Id { get; }

    public UpdateGenreResponse(Guid id)
        => Id = id;
}