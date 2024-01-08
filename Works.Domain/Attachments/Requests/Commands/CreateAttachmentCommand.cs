using System.ComponentModel.DataAnnotations;
using FavoriteLiterature.Works.Domain.Attachments.Responses.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FavoriteLiterature.Works.Domain.Attachments.Requests.Commands;

public class CreateAttachmentCommand : IRequest<CreateAttachmentResponse>
{
    [Required]
    public Guid WorkId { get; set; }

    [Required]
    public IFormFile File { get; set; }
}