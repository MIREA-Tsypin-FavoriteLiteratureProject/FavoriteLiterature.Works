using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FavoriteLiterature.Works.Domain.Works.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Works.Requests.Commands;

public class UpdateWorkRatingCommand : IRequest<UpdateWorkRatingResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    [Required]
    public decimal Rating { get; set; }
}