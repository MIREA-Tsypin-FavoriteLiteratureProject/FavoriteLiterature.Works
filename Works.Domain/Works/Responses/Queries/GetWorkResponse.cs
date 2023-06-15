using FavoriteLiterature.Works.Domain.Authors.Responses.Queries;
using FavoriteLiterature.Works.Domain.Genres.Responses.Queries;

namespace FavoriteLiterature.Works.Domain.Works.Responses.Queries;

public class GetWorkResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Rating { get; set; }

    public string? Description { get; set; }
    
    public ICollection<GetAuthorResponse> Authors { get; set; }

    public ICollection<GetGenreResponse> Genres { get; set; }

    public ICollection<Guid> Attachments { get; set; }
}