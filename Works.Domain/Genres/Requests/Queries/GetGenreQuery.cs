using FavoriteLiterature.Works.Domain.Genres.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Genres.Requests.Queries;

public class GetGenreQuery : IRequest<GetGenreResponse>
{
    public string Name { get; }

    public GetGenreQuery(string name)
        => Name = name;
}