namespace FavoriteLiterature.Works.Domain.Genres.Responses.Queries;

public class GetAllGenresItemResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}