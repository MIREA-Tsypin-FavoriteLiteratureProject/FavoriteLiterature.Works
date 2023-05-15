using FavoriteLiterature.Works.Domain.Common.Pagination.Responses;

namespace FavoriteLiterature.Works.Domain.Genres.Responses.Queries;

public class GetAllGenresResponse : PagedResponse<GetAllGenresItemResponse>
{
    public GetAllGenresResponse(IEnumerable<GetAllGenresItemResponse> items) : base(items)
    {
    }
}