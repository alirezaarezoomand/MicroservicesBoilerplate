namespace Seedworks.Core.Queries;

public abstract class PagedSortableQueryFilter<T>  where T : ISortablePropertyCollection
{
    private int _pageNumber;
    private int _pageSize;
    protected PagedSortableQueryFilter(T sortablePropertyCollection)
    {
        SortProperties = new List<SortProperty>() { 
            new SortProperty(sortablePropertyCollection.GetDefault(), SortDirection.Asc)};

        _pageNumber = 1;
        _pageSize = 10;
    }

    public List<SortProperty> SortProperties { get; set; }

    public int PageNumber
    {
        get
        {
            return _pageNumber;
        }
        set
        {
            _pageNumber = value > 1 ? value : 1;
        }
    }
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = value > 1 ? value : 10;
        }
    }

    public int SkipCount() => (PageNumber * PageSize) - PageSize;

}
