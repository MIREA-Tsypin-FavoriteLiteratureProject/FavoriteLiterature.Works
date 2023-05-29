using FavoriteLiterature.Works.Domain.Common.Pagination.Responses;

namespace FavoriteLiterature.Works.Domain.Authors.Responses.Queries;

public class GetAllAuthorsResponse : PagedResponse<GetAllAuthorsItemResponse>
{
    public GetAllAuthorsResponse(IEnumerable<GetAllAuthorsItemResponse> items) : base(items)
    {
    }
}