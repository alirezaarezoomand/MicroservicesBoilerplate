using System.Linq.Expressions;

namespace Seedworks.Core.Queries;

public abstract class QueryHandlerBase<TEntity>
{
    protected QueryHandlerBase()
    {
        SortFunctions = new Dictionary<string, Expression<Func<TEntity, object>>>();
        InitializeSortFunctions();
    }

    protected Dictionary<string, Expression<Func<TEntity, object>>> SortFunctions;
    protected abstract void InitializeSortFunctions();
}
