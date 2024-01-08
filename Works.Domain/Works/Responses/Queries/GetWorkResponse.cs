using FavoriteLiterature.Works.Domain.Authors.Responses.Queries;
using FavoriteLiterature.Works.Domain.Genres.Responses.Queries;

namespace FavoriteLiterature.Works.Domain.Works.Responses.Queries;

public class GetWorkResponse
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public decimal Rating { get; set; }

    public string? Description { get; set; }

    public required ICollection<GetAuthorResponse> Authors { get; set; }

    public required ICollection<GetGenreResponse> Genres { get; set; }

    public required ICollection<Guid> Attachments { get; set; }
}