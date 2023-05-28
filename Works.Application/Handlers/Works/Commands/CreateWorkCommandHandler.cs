using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Works.Requests.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Works.Commands;

public sealed class CreateWorkCommandHandler : IRequestHandler<CreateWorkCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateWorkCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateWorkCommand command, CancellationToken cancellationToken)
    {
        var workData = new Work
        {
            Name = command.Name,
            Description = command.Description,
        };

        foreach (var authorId in command.Authors)
        {
            var authorData = await _unitOfWork.AuthorsRepository.GetAsync(x =>
                    x.Id == authorId,
                cancellationToken);
            if (authorData == null)
            {
                throw new ArgumentException($"Author ({authorId}) is not exists!", nameof(authorId));
            }

            workData.Authors.Add(authorData);
        }

        foreach (var genresId in command.Genres)
        {
            var genreData = await _unitOfWork.GenresRepository.GetAsync(x =>
                    x.Id == genresId,
                cancellationToken);
            if (genreData == null)
            {
                throw new ArgumentException($"Genre ({genresId}) is not exists!", nameof(genresId));
            }

            workData.Genres.Add(genreData);
        }
        
        await _unitOfWork.BeginTransactionAsync(new[]
        {
            () => _unitOfWork.WorksRepository.Add(workData)
        });
    }
}