using AutoMapper;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Works.Requests.Commands;
using FavoriteLiterature.Works.Domain.Works.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Works.Commands;

public sealed class CreateWorkCommandHandler : IRequestHandler<CreateWorkCommand, CreateWorkResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateWorkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateWorkResponse> Handle(CreateWorkCommand command, CancellationToken cancellationToken)
    {
        var workData = _mapper.Map<Work>(command);

        foreach (var authorId in command.AuthorIds)
        {
            var authorData = await _unitOfWork.AuthorsRepository.GetAsync(x =>
                    x.Id == authorId,
                cancellationToken);
            if (authorData == null)
            {
                throw new ArgumentException($"{authorId} is not exists", nameof(authorId));
            }

            workData.Authors.Add(authorData);
        }

        foreach (var genreId in command.GenreIds)
        {
            var genreData = await _unitOfWork.GenresRepository.GetAsync(x =>
                    x.Id == genreId,
                cancellationToken);
            if (genreData == null)
            {
                throw new ArgumentException($"{genreId} is not exist.", nameof(genreId));
            }

            workData.Genres.Add(genreData);
        }

        await _unitOfWork.BeginTransactionAsync(new[]
        {
            () => _unitOfWork.WorksRepository.Add(workData)
        });

        return new CreateWorkResponse(workData.Id);
    }
}