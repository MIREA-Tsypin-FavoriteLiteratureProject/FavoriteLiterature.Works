using App.Metrics;
using FavoriteLiterature.Works.Domain.Works.Requests.Commands;
using FavoriteLiterature.Works.Domain.Works.Requests.Queries;
using FavoriteLiterature.Works.Domain.Works.Responses.Commands;
using FavoriteLiterature.Works.Domain.Works.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Works.Controllers;

public sealed class WorksController : BaseApiController
{
    public WorksController(IMediator mediator, IMetrics metrics, ILogger<WorksController> logger) 
        : base(mediator, metrics, logger)
    {
    }

    /// <summary>
    /// Получение всех работ с механизмом пагинации
    /// </summary>
    [HttpGet]
    public async Task<GetAllWorksResponse> GetAllAsync([FromQuery] GetAllWorksQuery query, CancellationToken cancellationToken)
        => await Mediator.Send(query, cancellationToken);

    /// <summary>
    /// Получение одной работы по ее уникальному идентификатору
    /// </summary>
    /// <param name="id">Уникальный идентификатор работы</param>
    [HttpGet("{id:guid}")]
    public async Task<GetWorkResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        => await Mediator.Send(new GetWorkQuery(id), cancellationToken);

    /// <summary>
    /// Создание работы автора
    /// </summary>
    /// <param name="command">Модель создания работы</param>
    [HttpPost]
    public async Task<CreateWorkResponse> CreateAsync(CreateWorkCommand command, CancellationToken cancellationToken)
        => await Mediator.Send(command, cancellationToken);

    /// <summary>
    /// Обновление существующей работы автора
    /// </summary>
    /// <param name="id">Уникальный идентификатор работы</param>
    /// <param name="command">Модель обновления работы</param>
    [HttpPut("{id:guid}")]
    public async Task<UpdateWorkResponse> UpdateAsync(Guid id, UpdateWorkCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        return await Mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Обновление рейтинга у работы
    /// </summary>
    /// <param name="id">Уникальный идентификатор работы</param>
    /// <param name="command">Модель обновления рейтинга</param>
    /// <returns></returns>
    [HttpPatch("{id:guid}")]
    public async Task<UpdateWorkRatingResponse> UpdateWorkRatingAsync(Guid id, UpdateWorkRatingCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        return await Mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Удаление существующей работы
    /// </summary>
    /// <param name="id">Уникальный идентификатор работы</param>
    [HttpDelete("{id:guid}")]
    public async Task<DeleteWorkResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await Mediator.Send(new DeleteWorkCommand(id), cancellationToken);
}