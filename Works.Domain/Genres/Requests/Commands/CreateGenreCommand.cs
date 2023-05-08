using System.ComponentModel.DataAnnotations;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Genres.Requests.Commands;

public class CreateGenreCommand : IRequest<CreateGenreCommand>
{
    [Required]
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }
}