namespace FavoriteLiterature.Works.Domain.Works.Responses.Queries;

public class GetAllWorksItemResponse
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public decimal Rating { get; set; }

    public string? Description { get; set; }

    public required ICollection<string> Authors { get; set; }

    public required ICollection<string> Genres { get; set; }
}