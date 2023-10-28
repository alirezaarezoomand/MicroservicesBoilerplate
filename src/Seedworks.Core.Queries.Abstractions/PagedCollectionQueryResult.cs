namespace Seedworks.Core.Queries;

public class PagedCollectionQueryResult<T> : IQueryResult where T : IQueryResult
{
    public PagedCollectionQueryResult(int pageNumber, int pageSize, int totalItems, List<T> items)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalItems = totalItems;
        Items = items;
    }
    public int PageNumber { get; }
    public int PageSize { get; }
    public int TotalItems { get; }
    public List<T> Items { get; }
}
