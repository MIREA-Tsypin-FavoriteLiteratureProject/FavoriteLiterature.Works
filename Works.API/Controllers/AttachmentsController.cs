using App.Metrics;
using FavoriteLiterature.Works.Domain.Attachments.Requests.Commands;
using FavoriteLiterature.Works.Domain.Attachments.Requests.Queries;
using FavoriteLiterature.Works.Domain.Attachments.Responses.Commands;
using FavoriteLiterature.Works.Domain.Attachments.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Works.Controllers;

public sealed class AttachmentsController : BaseApiController
{
    public AttachmentsController(IMediator mediator, IMetrics metrics, ILogger<AttachmentsController> logger) 
        : base(mediator, metrics, logger)
    {
    }

    /// <summary>
    /// Получение всех вложений с механизмом пагинации
    /// </summary>
    [HttpGet]
    public async Task<GetAllAttachmentsResponse> GetAllAsync([FromQuery] GetAllAttachmentsQuery query, CancellationToken cancellationToken)
        => await Mediator.Send(query, cancellationToken);

    /// <summary>
    /// Получение одного вложения по его уникальному идентификатору
    /// </summary>
    /// <param name="id">Уникальный идентификатор вложения</param>
    [HttpGet("{id:guid}")]
    public async Task<FileContentResult> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetAttachmentQuery(id), cancellationToken);
        return File(response.FileContents, response.ContentType, response.FileDownloadName);
    }

    /// <summary>
    /// Создание вложения
    /// </summary>
    /// <param name="command">Модель создания вложения</param>
    [HttpPost]
    public async Task<CreateAttachmentResponse> CreateAsync([FromForm] CreateAttachmentCommand command, 
        CancellationToken cancellationToken) 
        => await Mediator.Send(command, cancellationToken);

    /// <summary>
    /// Удаление существующего вложения
    /// </summary>
    /// <param name="id">Уникальный идентификатор вложения</param>
    [HttpDelete("{id:guid}")]
    public async Task<DeleteAttachmentResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await Mediator.Send(new DeleteAttachmentCommand(id), cancellationToken);
}