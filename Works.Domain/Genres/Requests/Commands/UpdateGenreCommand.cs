using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Genres.Requests.Commands;

public class UpdateGenreCommand : IRequest<UpdateGenreResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}