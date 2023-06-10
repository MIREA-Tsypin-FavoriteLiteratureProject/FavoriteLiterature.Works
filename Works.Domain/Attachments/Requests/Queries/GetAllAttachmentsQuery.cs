using FavoriteLiterature.Works.Domain.Attachments.Responses.Queries;
using FavoriteLiterature.Works.Domain.Common.Pagination.Requests;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Attachments.Requests.Queries;

public class GetAllAttachmentsQuery : PagedRequest, IRequest<GetAllAttachmentsResponse>
{
}