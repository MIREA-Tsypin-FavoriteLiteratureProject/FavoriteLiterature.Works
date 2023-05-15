using AutoMapper;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Genres.Requests.Queries;
using FavoriteLiterature.Works.Domain.Genres.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Genres.Queries;

public sealed class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, GetAllGenresResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllGenresQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetAllGenresResponse> Handle(GetAllGenresQuery query, CancellationToken cancellationToken)
    {
        var genresData = await _unitOfWork.GenresRepository.GetAllAsync(
            query.Skip, query.Take, cancellationToken);

        return new GetAllGenresResponse(_mapper.Map<IEnumerable<GetAllGenresItemResponse>>(genresData));
    }
}