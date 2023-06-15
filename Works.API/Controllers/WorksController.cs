using FavoriteLiterature.Works.Domain.Works.Requests.Commands;
using FavoriteLiterature.Works.Domain.Works.Requests.Queries;
using FavoriteLiterature.Works.Domain.Works.Responses.Commands;
using FavoriteLiterature.Works.Domain.Works.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Works.Controllers;

public sealed class WorksController : BaseApiController
{
    public WorksController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<GetAllWorksResponse> GetAllAsync([FromQuery] GetAllWorksQuery query, CancellationToken cancellationToken)
        => await _mediator.Send(query, cancellationToken);

    [HttpGet("{id:guid}")]
    public async Task<GetWorkResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        => await _mediator.Send(new GetWorkQuery(id), cancellationToken);

    [HttpPatch("{id:guid}")]
    public async Task<UpdateWorkRatingResponse> UpdateWorkRatingAsync(Guid id, UpdateWorkRatingCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        return await _mediator.Send(command, cancellationToken);
    }
}