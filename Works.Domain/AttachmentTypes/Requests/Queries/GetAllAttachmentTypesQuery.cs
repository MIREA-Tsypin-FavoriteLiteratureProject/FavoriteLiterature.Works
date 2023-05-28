using FavoriteLiterature.Works.Domain.AttachmentTypes.Responses.Queries;
using FavoriteLiterature.Works.Domain.Common.Pagination.Requests;
using MediatR;

namespace FavoriteLiterature.Works.Domain.AttachmentTypes.Requests.Queries;

public class GetAllAttachmentTypesQuery : PagedRequest, IRequest<GetAllAttachmentTypesResponse>
{
}