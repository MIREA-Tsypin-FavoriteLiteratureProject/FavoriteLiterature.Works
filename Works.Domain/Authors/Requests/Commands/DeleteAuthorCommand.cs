using FavoriteLiterature.Works.Domain.Authors.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Authors.Requests.Commands;

public class DeleteAuthorCommand : IRequest<DeleteAuthorResponse>
{
    public Guid Id { get; }

    public DeleteAuthorCommand(Guid id)
        => Id = id;
}