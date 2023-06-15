namespace FavoriteLiterature.Works.Domain.Works.Responses.Queries;

public class GetAllWorksItemResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Rating { get; set; }

    public string? Description { get; set; }

    public ICollection<string> Authors { get; set; }

    public ICollection<string> Genres { get; set; }
}