namespace FavoriteLiterature.Works.Domain.Common.Pagination.Requests;

public abstract class PagedRequest
{
    public int? Skip { get; set; }
    public int? Take { get; set; }
}