using System.ComponentModel.DataAnnotations;
using FavoriteLiterature.Works.Domain.Authors.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Authors.Requests.Commands;

public class CreateAuthorCommand : IRequest<CreateAuthorResponse>
{
    [Required]
    public string Alias { get; set; } = null!;

    [Required]
    public string PublicEmail { get; set; } = null!;
    
    public string? Description { get; set; }
    
    [Required]
    public Guid UserId { get; set; }
}