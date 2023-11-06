using FavoriteLiterature.Works.Domain.Authors.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Authors.Requests.Commands;

public class CreateAuthorCommand : IRequest<CreateAuthorResponse>
{
    public required string NickName { get; set; }

    public string? FullName { get; set; }

    public required string PublicEmail { get; set; }

    public string? Description { get; set; }
}