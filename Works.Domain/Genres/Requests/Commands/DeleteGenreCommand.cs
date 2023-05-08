using MediatR;

namespace FavoriteLiterature.Works.Domain.Genres.Requests.Commands;

public class DeleteGenreCommand : IRequest<DeleteGenreCommand>
{
    public string Name { get; set; }

    public DeleteGenreCommand(string name)
        => Name = name;
}