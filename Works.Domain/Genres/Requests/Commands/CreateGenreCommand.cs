using System.ComponentModel.DataAnnotations;
using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Genres.Requests.Commands;

public class CreateGenreCommand : IRequest<CreateGenreResponse>
{
    [Required]
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }
}