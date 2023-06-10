using AutoMapper;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Works.Requests.Queries;
using FavoriteLiterature.Works.Domain.Works.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Works.Queries;

public sealed class GetWorkQueryHandler : IRequestHandler<GetWorkQuery, GetWorkResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetWorkQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetWorkResponse> Handle(GetWorkQuery query, CancellationToken cancellationToken)
    {
        var workData = await _unitOfWork.WorksRepository.GetFullWork(x =>
                x.Id == query.Id,
            cancellationToken);

        return _mapper.Map<GetWorkResponse>(workData);
    }
}