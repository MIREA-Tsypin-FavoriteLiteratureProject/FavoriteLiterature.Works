using FavoriteLiterature.Works.Domain.Works.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Works.Requests.Queries;

public class GetWorkQuery : IRequest<GetWorkResponse>
{
    public Guid Id { get; }

    public GetWorkQuery(Guid id)
        => Id = id;
}