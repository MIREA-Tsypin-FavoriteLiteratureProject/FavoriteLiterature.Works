namespace FavoriteLiterature.Works.Domain.Authors.Responses.Queries;

public class GetAuthorResponse
{
    public Guid Id { get; set; }

    public string PublicEmail { get; set; } = null!;

    public string? Description { get; set; }

    public Guid UserId { get; set; }
}