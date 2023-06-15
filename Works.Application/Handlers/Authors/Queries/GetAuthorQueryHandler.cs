using AutoMapper;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Authors.Requests.Queries;
using FavoriteLiterature.Works.Domain.Authors.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Authors.Queries;

public sealed class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, GetAuthorResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAuthorQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetAuthorResponse> Handle(GetAuthorQuery query, CancellationToken cancellationToken)
    {
        var authorData = await _unitOfWork.AuthorsRepository.GetAsync(x =>
                x.Id == query.Id,
            cancellationToken);

        return _mapper.Map<GetAuthorResponse>(authorData);
    }
}