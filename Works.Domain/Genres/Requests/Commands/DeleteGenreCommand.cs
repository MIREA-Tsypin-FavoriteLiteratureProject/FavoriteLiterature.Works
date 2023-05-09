using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Genres.Requests.Commands;

public class DeleteGenreCommand : IRequest<DeleteGenreResponse>
{
    public Guid Id { get; set; }

    public DeleteGenreCommand(Guid id)
        => Id = id;
}