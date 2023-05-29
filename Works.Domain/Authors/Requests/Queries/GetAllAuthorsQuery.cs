using FavoriteLiterature.Works.Domain.Authors.Responses.Queries;
using FavoriteLiterature.Works.Domain.Common.Pagination.Requests;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Authors.Requests.Queries;

public class GetAllAuthorsQuery : PagedRequest, IRequest<GetAllAuthorsResponse>
{
}