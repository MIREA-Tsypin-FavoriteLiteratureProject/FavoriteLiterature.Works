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

    /// <summary>
    /// Получение всех жанров с механизмом пагинации
    /// </summary>
    /// <param name="skip">Сколько пропустить</param>
    /// <param name="take">Сколько взять</param>
    /// <returns>Коллекция жанров в заданном диапазоне</returns>
    [HttpGet]
    public async Task<GetAllGenresResponse> GetAllAsync([FromQuery] GetAllGenresQuery query, CancellationToken cancellationToken)
        => await Mediator.Send(query, cancellationToken);

    /// <summary>
    /// Получение одного жанра по его уникальному идентификатору
    /// </summary>
    /// <param name="id">Уникальный идентификатор GUID</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<GetGenreResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        => await Mediator.Send(new GetGenreQuery(id), cancellationToken);

    /// <summary>
    /// Создание жанра
    /// </summary>
    /// <param name="command">Модель необходимая для создания жанра</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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