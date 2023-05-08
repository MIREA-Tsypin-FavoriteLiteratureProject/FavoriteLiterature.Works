using Newtonsoft.Json;

namespace FavoriteLiterature.Works.Domain.Common.Pagination.Responses;

public abstract class PagedResponse<T>
{
    protected PagedResponse(IEnumerable<T> items)
    {
        Items = items;
    }

    [JsonProperty("items")]
    public IEnumerable<T> Items { get; }
}