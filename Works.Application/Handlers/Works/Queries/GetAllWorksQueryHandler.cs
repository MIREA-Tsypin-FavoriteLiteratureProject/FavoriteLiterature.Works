using AutoMapper;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Works.Requests.Queries;
using FavoriteLiterature.Works.Domain.Works.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Works.Queries;

public sealed class GetAllWorksQueryHandler : IRequestHandler<GetAllWorksQuery, GetAllWorksResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllWorksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetAllWorksResponse> Handle(GetAllWorksQuery query, CancellationToken cancellationToken)
    {
        var worksData = await _unitOfWork.WorksRepository.GetAllWorksWithAuthorsAndGenresAsync(
            query.Skip, query.Take, cancellationToken);

        return new GetAllWorksResponse(_mapper.Map<IEnumerable<GetAllWorksItemResponse>>(worksData));
    }
}