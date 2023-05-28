using FavoriteLiterature.Works.Domain.AttachmentTypes.Requests.Queries;
using FavoriteLiterature.Works.Domain.AttachmentTypes.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Works.Controllers;

public sealed class AttachmentTypesController : BaseApiController
{
    public AttachmentTypesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<GetAllAttachmentTypesResponse> GetAllAsync([FromQuery] GetAllAttachmentTypesQuery query, CancellationToken cancellationToken)
        => await _mediator.Send(query, cancellationToken);
}