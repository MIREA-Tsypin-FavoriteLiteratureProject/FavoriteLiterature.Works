using AutoMapper;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Works.Requests.Commands;
using FavoriteLiterature.Works.Domain.Works.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Works.Commands;

public sealed class UpdateWorkCommandHandler : IRequestHandler<UpdateWorkCommand, UpdateWorkResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public UpdateWorkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<UpdateWorkResponse> Handle(UpdateWorkCommand command, CancellationToken cancellationToken)
    {
        var workData = await _unitOfWork.WorksRepository.GetAsync(work =>
                work.Id == command.Id,
            cancellationToken);
        if (workData == null)
        {
            throw new ArgumentException($"{command.Id} is not found.", nameof(command.Id));
        }

        _mapper.Map(command, workData);

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
            () => _unitOfWork.WorksRepository.Update(workData)
        });

        return new UpdateWorkResponse(workData.Id);
    }
}