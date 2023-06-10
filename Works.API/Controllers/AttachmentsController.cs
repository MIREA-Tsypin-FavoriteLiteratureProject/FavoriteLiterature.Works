using FavoriteLiterature.Works.Domain.Attachments.Requests.Queries;
using FavoriteLiterature.Works.Domain.Attachments.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Works.Controllers;

public sealed class AttachmentsController : BaseApiController
{
    public AttachmentsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id:guid}")]
    public async Task<FileContentResult> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAttachmentQuery(id), cancellationToken);
        return File(response.FileContents, response.ContentType, response.FileDownloadName);
    }

    [HttpGet]
    public async Task<GetAllAttachmentsResponse> GetAllAsync([FromQuery] GetAllAttachmentsQuery query, CancellationToken cancellationToken)
        => await _mediator.Send(query, cancellationToken);
}