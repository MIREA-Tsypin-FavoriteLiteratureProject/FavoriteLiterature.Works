using AutoMapper;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Genres.Requests.Commands;
using FavoriteLiterature.Works.Domain.Genres.Responses.Commands;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Genres.Commands;

public sealed class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, UpdateGenreResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public UpdateGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<UpdateGenreResponse> Handle(UpdateGenreCommand command, CancellationToken cancellationToken)
    {
        var genreData = await _unitOfWork.GenresRepository.GetAsync(genre =>
                genre.Id == command.Id,
            cancellationToken);
        if (genreData == null)
        {
            throw new ArgumentException($"{command.Id} is not found.", nameof(command.Id));
        }
        
        var isGenreNameExists = await _unitOfWork.GenresRepository.ExistsAsync(genre =>
                genre.Name == command.Name && genre.Name != genreData.Name,
            cancellationToken);
        if (isGenreNameExists)
        {
            throw new ArgumentException($"{command.Name} is exist.", nameof(command.Name));
        }

        _mapper.Map(command, genreData);
        
        await _unitOfWork.BeginTransactionAsync(new[]
        {
            () => _unitOfWork.GenresRepository.Update(genreData)
        });

        return new UpdateGenreResponse(genreData.Id);
    }
}