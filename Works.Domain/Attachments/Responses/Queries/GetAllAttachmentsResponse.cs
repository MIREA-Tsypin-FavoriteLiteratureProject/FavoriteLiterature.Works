using FavoriteLiterature.Works.Domain.Common.Pagination.Responses;

namespace FavoriteLiterature.Works.Domain.Attachments.Responses.Queries;

public class GetAllAttachmentsResponse : PagedResponse<GetAllAttachmentsItemResponse>
{
    public GetAllAttachmentsResponse(IEnumerable<GetAllAttachmentsItemResponse> items) : base(items)
    {
    }
}