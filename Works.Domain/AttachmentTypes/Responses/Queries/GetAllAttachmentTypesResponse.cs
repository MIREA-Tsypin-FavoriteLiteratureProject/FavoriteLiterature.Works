using FavoriteLiterature.Works.Domain.Common.Pagination.Responses;

namespace FavoriteLiterature.Works.Domain.AttachmentTypes.Responses.Queries;

public class GetAllAttachmentTypesResponse : PagedResponse<GetAllAttachmentTypesItemResponse>
{
    public GetAllAttachmentTypesResponse(IEnumerable<GetAllAttachmentTypesItemResponse> items) : base(items)
    {
    }
}