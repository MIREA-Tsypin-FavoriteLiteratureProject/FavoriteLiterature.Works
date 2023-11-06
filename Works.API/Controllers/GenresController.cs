using FavoriteLiterature.Works.Domain.Genres.Requests.Commands;
using FavoriteLiterature.Works.Domain.Genres.Requests.Queries;
using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using FavoriteLiterature.Works.Domain.Genres.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Works.Controllers;

public sealed class GenresController : BaseApiController
{
    public GenresController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<GetAllGenresResponse> GetAllAsync([FromQuery] GetAllGenresQuery query, CancellationToken cancellationToken)
        => await Mediator.Send(query, cancellationToken);

    [HttpGet("{id:guid}")]
    public async Task<GetGenreResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        => await Mediator.Send(new GetGenreQuery(id), cancellationToken);

    [HttpPost]
    public async Task<CreateGenreResponse> CreateAsync(CreateGenreCommand command, CancellationToken cancellationToken) 
        => await Mediator.Send(command, cancellationToken);

    [HttpPut("{id:guid}")]
    public async Task<UpdateGenreResponse> UpdateAsync(Guid id, [FromBody] UpdateGenreCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        return await Mediator.Send(command, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    public async Task<DeleteGenreResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await Mediator.Send(new DeleteGenreCommand(id), cancellationToken);
}