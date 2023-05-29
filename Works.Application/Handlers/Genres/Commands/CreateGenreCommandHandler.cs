using AutoMapper;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Genres.Requests.Commands;
using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Genres.Commands;

public sealed class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, CreateGenreResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateGenreResponse> Handle(CreateGenreCommand command, CancellationToken cancellationToken)
    {
        var isGenreDataExists = await _unitOfWork.GenresRepository.ExistsAsync(x =>
                x.Name == command.Name,
            cancellationToken);
        if (isGenreDataExists)
        {
            throw new ArgumentException($"{command.Name} is exist.", nameof(command.Name));
        }

        var genreData = _mapper.Map<Genre>(command);

        await _unitOfWork.BeginTransactionAsync(new[]
        {
            () => _unitOfWork.GenresRepository.Add(genreData)
        });

        return new CreateGenreResponse(genreData.Id);
    }
}