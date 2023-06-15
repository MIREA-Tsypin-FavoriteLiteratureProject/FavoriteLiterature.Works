namespace FavoriteLiterature.Works.Domain.RabbitMq;

public class DraftModel
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public List<Guid> Authors { get; set; }

    public List<Guid> Genres { get; set; }

    public List<string> Files { get; set; }
}