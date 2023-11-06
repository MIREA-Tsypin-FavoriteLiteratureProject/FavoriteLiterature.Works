using FavoriteLiterature.Works.Domain.Authors.Requests.Commands;
using FavoriteLiterature.Works.Domain.Authors.Requests.Queries;
using FavoriteLiterature.Works.Domain.Authors.Responses.Commands;
using FavoriteLiterature.Works.Domain.Authors.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Works.Controllers;

public sealed class AuthorsController : BaseApiController
{
    public AuthorsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<GetAllAuthorsResponse> GetAllAsync([FromQuery] GetAllAuthorsQuery query, CancellationToken cancellationToken)
        => await Mediator.Send(query, cancellationToken);

    [HttpGet("{id:guid}")]
    public async Task<GetAuthorResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        => await Mediator.Send(new GetAuthorQuery(id), cancellationToken);

    [HttpPost]
    public async Task<CreateAuthorResponse> CreateAsync(CreateAuthorCommand command, CancellationToken cancellationToken)
        => await Mediator.Send(command, cancellationToken);

    [HttpPut("{id:guid}")]
    public async Task<UpdateAuthorResponse> UpdateAsync(Guid id, [FromBody] UpdateAuthorCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        return await Mediator.Send(command, cancellationToken);
    }
}