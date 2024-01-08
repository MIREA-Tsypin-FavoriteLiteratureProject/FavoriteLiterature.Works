using FavoriteLiterature.Works.Domain.Works.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Works.Requests.Commands;

public class DeleteWorkCommand : IRequest<DeleteWorkResponse>
{
    public Guid Id { get; }

    public DeleteWorkCommand(Guid id)
        => Id = id;
}