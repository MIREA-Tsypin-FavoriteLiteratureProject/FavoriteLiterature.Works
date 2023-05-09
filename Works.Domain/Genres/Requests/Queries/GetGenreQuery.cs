using FavoriteLiterature.Works.Domain.Genres.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Genres.Requests.Queries;

public class GetGenreQuery : IRequest<GetGenreResponse>
{
    public Guid Id { get; }

    public GetGenreQuery(Guid id)
        => Id = id;
}