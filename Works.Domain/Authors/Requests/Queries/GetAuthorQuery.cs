using FavoriteLiterature.Works.Domain.Authors.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Authors.Requests.Queries;

public class GetAuthorQuery : IRequest<GetAuthorResponse>
{
    public Guid Id { get; }

    public GetAuthorQuery(Guid id)
        => Id = id;
}