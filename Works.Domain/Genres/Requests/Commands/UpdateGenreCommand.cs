using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using MediatR;
using Newtonsoft.Json;

namespace FavoriteLiterature.Works.Domain.Genres.Requests.Commands;

public class UpdateGenreCommand : IRequest<UpdateGenreResponse>
{
    [JsonIgnore]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}