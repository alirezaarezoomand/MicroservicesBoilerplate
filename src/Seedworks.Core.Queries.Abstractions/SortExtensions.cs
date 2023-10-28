﻿using System.Linq.Expressions;

namespace Seedworks.Core.Queries;

public static class SortExtensions
{
    public static IQueryable<T> ApplySort<T>(this IQueryable<T> query, Dictionary<string, Expression<Func<T, object>>> sortFunctions, string propertyName, SortDirection direction)
        where T : class
    {
        var sortFunc = sortFunctions.FirstOrDefault(k => k.Key.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));
        if (direction == SortDirection.Asc)
        {
            query = query.OrderBy(sortFunc.Value);
        }
        else
        {
            query = query.OrderByDescending(sortFunc.Value);
        }
        return query;
    }
}