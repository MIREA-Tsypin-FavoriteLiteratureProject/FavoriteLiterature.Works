using FavoriteLiterature.Works.Domain.Genres.Requests.Commands;
using FavoriteLiterature.Works.Domain.Genres.Requests.Queries;
using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using FavoriteLiterature.Works.Domain.Genres.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Works.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class GenresController : ControllerBase
{
    private readonly IMediator _mediator;

    public GenresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<GetGenreResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        => await _mediator.Send(new GetGenreQuery(id), cancellationToken);

    [HttpPost]
    public async Task<CreateGenreResponse> CreateAsync(CreateGenreCommand command, CancellationToken cancellationToken) 
        => await _mediator.Send(command, cancellationToken);
}