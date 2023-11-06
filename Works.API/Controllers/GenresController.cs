using App.Metrics;
using FavoriteLiterature.Works.Domain.Genres.Requests.Commands;
using FavoriteLiterature.Works.Domain.Genres.Requests.Queries;
using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using FavoriteLiterature.Works.Domain.Genres.Responses.Queries;
using FavoriteLiterature.Works.Metrics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Works.Controllers;

public sealed class GenresController : BaseApiController
{
    public GenresController(IMediator mediator, IMetrics metrics) : base(mediator, metrics)
    {
    }

    /// <summary>
    /// Получение всех жанров с механизмом пагинации
    /// </summary>
    [HttpGet]
    public async Task<GetAllGenresResponse> GetAllAsync([FromQuery] GetAllGenresQuery query, CancellationToken cancellationToken)
        => await Mediator.Send(query, cancellationToken);

    /// <summary>
    /// Получение одного жанра по его уникальному идентификатору
    /// </summary>
    /// <param name="id">Уникальный идентификатор жанра</param>
    [HttpGet("{id:guid}")]
    public async Task<GetGenreResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        => await Mediator.Send(new GetGenreQuery(id), cancellationToken);

    /// <summary>
    /// Создание жанра
    /// </summary>
    /// <param name="command">Модель создания жанра</param>
    [HttpPost]
    public async Task<CreateGenreResponse> CreateAsync(CreateGenreCommand command, CancellationToken cancellationToken)
    {
        Metrics.Measure.Counter.Increment(MetricsRegistry.CreatedGenresCounter);
        return await Mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Обновление существующего жанра
    /// </summary>
    /// <param name="id">Уникальный идентификатор жанра</param>
    /// <param name="command">Модель обновления жанра</param>
    [HttpPut("{id:guid}")]
    public async Task<UpdateGenreResponse> UpdateAsync(Guid id, [FromBody] UpdateGenreCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        return await Mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Удаление существующего жанра
    /// </summary>
    /// <param name="id">Уникальный идентификатор жанра</param>
    [HttpDelete("{id:guid}")]
    public async Task<DeleteGenreResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await Mediator.Send(new DeleteGenreCommand(id), cancellationToken);
}