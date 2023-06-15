namespace FavoriteLiterature.Works.Domain.Genres.Responses.Commands;

public class CreateGenreResponse
{
    public Guid Id { get; }

    public CreateGenreResponse(Guid id)
        => Id = id;
}