using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Genres.Requests.Commands;

public class UpdateGenreCommand : IRequest<UpdateGenreResponse>
{
    public string? Name { get; set; }

    public string? Description { get; set; }
}