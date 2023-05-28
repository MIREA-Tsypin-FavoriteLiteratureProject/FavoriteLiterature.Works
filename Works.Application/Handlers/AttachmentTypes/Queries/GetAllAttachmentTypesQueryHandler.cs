using AutoMapper;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.AttachmentTypes.Requests.Queries;
using FavoriteLiterature.Works.Domain.AttachmentTypes.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.AttachmentTypes.Queries;

public sealed class GetAllAttachmentTypesQueryHandler : IRequestHandler<GetAllAttachmentTypesQuery, GetAllAttachmentTypesResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllAttachmentTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<GetAllAttachmentTypesResponse> Handle(GetAllAttachmentTypesQuery query, CancellationToken cancellationToken)
    {
        var attachmentTypesData = await _unitOfWork.AttachmentTypesRepository.GetAllAsync(
            query.Skip, query.Take, cancellationToken);

        return new GetAllAttachmentTypesResponse(_mapper.Map<IEnumerable<GetAllAttachmentTypesItemResponse>>(attachmentTypesData));
    }
}