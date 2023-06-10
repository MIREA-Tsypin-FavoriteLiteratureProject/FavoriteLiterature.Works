using AutoMapper;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Attachments.Requests.Queries;
using FavoriteLiterature.Works.Domain.Attachments.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Application.Handlers.Attachments.Queries;

public sealed class GetAllAttachmentQueryHandler : IRequestHandler<GetAllAttachmentsQuery, GetAllAttachmentsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllAttachmentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetAllAttachmentsResponse> Handle(GetAllAttachmentsQuery query, CancellationToken cancellationToken)
    {
        var attachmentsData = await _unitOfWork.AttachmentsRepository.GetAllAsync(
            query.Skip, query.Take, 
            cancellationToken);

        return new GetAllAttachmentsResponse(_mapper.Map<IEnumerable<GetAllAttachmentsItemResponse>>(attachmentsData));

    }
}