namespace Seedworks.Core.Queries;

public class SortProperty
{
    public SortProperty(string propertyName, SortDirection sortDirection)
    {
        PropertyName = propertyName;
        SortDirection = sortDirection;
    }

    public string PropertyName { get; private set; }
    public SortDirection SortDirection { get; set; }
}
