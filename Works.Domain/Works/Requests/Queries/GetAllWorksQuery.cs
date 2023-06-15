using FavoriteLiterature.Works.Domain.Common.Pagination.Requests;
using FavoriteLiterature.Works.Domain.Works.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Works.Requests.Queries;

public class GetAllWorksQuery : PagedRequest, IRequest<GetAllWorksResponse>
{
}