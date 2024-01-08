using FavoriteLiterature.Works.Domain.Works.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Works.Requests.Commands;

public class CreateWorkCommand : IRequest<CreateWorkResponse>
{
    public required string Name { get; set; }

    public string? Description { get; set; } 

    public required List<Guid> AuthorIds { get; set; }

    public required List<Guid> GenreIds { get; set; }
}