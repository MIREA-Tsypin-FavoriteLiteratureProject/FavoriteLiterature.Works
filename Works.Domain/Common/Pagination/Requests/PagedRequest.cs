namespace FavoriteLiterature.Works.Domain.Common.Pagination.Requests;

public abstract class PagedRequest
{
    /// <summary>
    /// По умолчанию 0
    /// </summary>
    public int Skip { get; set; } = 0;

    /// <summary>
    /// тест
    /// </summary>
    public int Take { get; set; } = 10;
}