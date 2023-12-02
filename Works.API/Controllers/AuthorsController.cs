using App.Metrics;
using FavoriteLiterature.Works.Domain.Authors.Requests.Commands;
using FavoriteLiterature.Works.Domain.Authors.Requests.Queries;
using FavoriteLiterature.Works.Domain.Authors.Responses.Commands;
using FavoriteLiterature.Works.Domain.Authors.Responses.Queries;
using FavoriteLiterature.Works.Metrics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Works.Controllers;

public sealed class AuthorsController : BaseApiController
{
    public AuthorsController(IMediator mediator, IMetrics metrics, ILogger<AuthorsController> logger) 
        : base(mediator, metrics, logger)
    {
    }

    /// <summary>
    /// Получение всех авторов с механизмом пагинации
    /// </summary>
    [HttpGet]
    public async Task<GetAllAuthorsResponse> GetAllAsync([FromQuery] GetAllAuthorsQuery query, CancellationToken cancellationToken)
        => await Mediator.Send(query, cancellationToken);

    /// <summary>
    /// Получение одного автора по его уникальному идентификатору
    /// </summary>
    /// <param name="id">Уникальный идентификатор автора</param>
    [HttpGet("{id:guid}")]
    public async Task<GetAuthorResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        => await Mediator.Send(new GetAuthorQuery(id), cancellationToken);

    /// <summary>
    /// Создание автора
    /// </summary>
    /// <param name="command">Модель создания автора</param>
    [HttpPost]
    public async Task<CreateAuthorResponse> CreateAsync(CreateAuthorCommand command, CancellationToken cancellationToken)
    {
        Metrics.Measure.Counter.Increment(MetricsRegistry.CreatedAuthorsCounter);
        return await Mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Обновление существующего автора
    /// </summary>
    /// <param name="id">Уникальный идентификатор автора</param>
    /// <param name="command">Модель обновления автора</param>
    [HttpPut("{id:guid}")]
    public async Task<UpdateAuthorResponse> UpdateAsync(Guid id, [FromBody] UpdateAuthorCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        return await Mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Удаление существующего автора
    /// </summary>
    /// <param name="id">Уникальный идентификатор автора</param>
    [HttpDelete("{id:guid}")]
    public async Task<DeleteAuthorResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await Mediator.Send(new DeleteAuthorCommand(id), cancellationToken);
}