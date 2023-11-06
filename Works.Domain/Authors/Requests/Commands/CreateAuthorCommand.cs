using FavoriteLiterature.Works.Domain.Authors.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Authors.Requests.Commands;

public class CreateAuthorCommand : IRequest<CreateAuthorResponse>
{
    public required string Alias { get; set; }

    public required string PublicEmail { get; set; }

    public string? Description { get; set; }
}