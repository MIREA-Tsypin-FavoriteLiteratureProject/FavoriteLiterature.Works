using AutoMapper;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Authors.Requests.Queries;
using FavoriteLiterature.Works.Domain.Authors.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Authors.Queries;

public sealed class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, GetAllAuthorsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllAuthorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetAllAuthorsResponse> Handle(GetAllAuthorsQuery query, CancellationToken cancellationToken)
    {
        var authorData = await _unitOfWork.AuthorsRepository.GetAllAsync(
            query.Skip, query.Take, cancellationToken);

        return new GetAllAuthorsResponse(_mapper.Map<IEnumerable<GetAllAuthorsItemResponse>>(authorData));

    }
}