using FavoriteLiterature.Works.Domain.Common.Pagination.Requests;
using FavoriteLiterature.Works.Domain.Genres.Responses.Queries;
using MediatR;

namespace FavoriteLiterature.Works.Domain.Genres.Requests.Queries;

public class GetAllGenresQuery : PagedRequest, IRequest<GetAllGenresResponse>
{
}