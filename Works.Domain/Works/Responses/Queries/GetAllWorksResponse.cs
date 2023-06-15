using FavoriteLiterature.Works.Domain.Common.Pagination.Responses;

namespace FavoriteLiterature.Works.Domain.Works.Responses.Queries;

public class GetAllWorksResponse : PagedResponse<GetAllWorksItemResponse>
{
    public GetAllWorksResponse(IEnumerable<GetAllWorksItemResponse> items) : base(items)
    {
    }
}