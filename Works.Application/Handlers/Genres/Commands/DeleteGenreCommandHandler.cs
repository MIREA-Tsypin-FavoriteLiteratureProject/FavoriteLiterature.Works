using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Genres.Requests.Commands;
using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Genres.Commands;

public sealed class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, DeleteGenreResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGenreCommandHandler(IUnitOfWork unitOfWork) 
        => _unitOfWork = unitOfWork;

    public async Task<DeleteGenreResponse> Handle(DeleteGenreCommand command, CancellationToken cancellationToken)
    {
        var genreData = await _unitOfWork.GenresRepository.GetAsync(x =>
                x.Id == command.Id,
            cancellationToken);
        if (genreData == null)
        {
            throw new ArgumentException($"{command.Id} is not found.", nameof(command.Id));
        }

        await _unitOfWork.BeginTransactionAsync(new List<Action>
        {
            () => _unitOfWork.GenresRepository.Remove(genreData)
        });

        return new DeleteGenreResponse(command.Id);
    }
}