using AutoMapper;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Genres.Requests.Queries;
using FavoriteLiterature.Works.Domain.Genres.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Genres.Queries;

public sealed class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, GetGenreResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetGenreQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetGenreResponse> Handle(GetGenreQuery query, CancellationToken cancellationToken)
    {
        var genreData = await _unitOfWork.GenresRepository.GetAsync(x =>
                x.Id == query.Id,
            cancellationToken);

        return _mapper.Map<GetGenreResponse>(genreData);
    }
}