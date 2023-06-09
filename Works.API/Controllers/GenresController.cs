using FavoriteLiterature.Works.Application.Policies;
using FavoriteLiterature.Works.Domain.Genres.Requests.Commands;
using FavoriteLiterature.Works.Domain.Genres.Requests.Queries;
using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using FavoriteLiterature.Works.Domain.Genres.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Works.Controllers;

public sealed class GenresController : BaseApiController
{
    public GenresController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<GetAllGenresResponse> GetAllAsync([FromQuery] GetAllGenresQuery query, CancellationToken cancellationToken)
        => await _mediator.Send(query, cancellationToken);

    [HttpGet("{id:guid}")]
    public async Task<GetGenreResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        => await _mediator.Send(new GetGenreQuery(id), cancellationToken);

    [HttpPost]
    [Authorize(Policy = nameof(RolePolicy.Critic))]
    public async Task<CreateGenreResponse> CreateAsync(CreateGenreCommand command, CancellationToken cancellationToken) 
        => await _mediator.Send(command, cancellationToken);

    [HttpPut("{id:guid}")]
    [Authorize(Policy = nameof(RolePolicy.Critic))]
    public async Task<UpdateGenreResponse> UpdateAsync(Guid id, [FromBody] UpdateGenreCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = nameof(RolePolicy.Critic))]
    public async Task<DeleteGenreResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await _mediator.Send(new DeleteGenreCommand(id), cancellationToken);
}