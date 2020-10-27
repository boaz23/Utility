using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Utility.Linq
{
    public static class QueryableExtensions
    {
        // It does not make sense to have IQueryable<TSource> extensions which
        // order by no property (field, attribute or column) since when the query actually gets to the
        // underlying structure (e.g. SQL), it has to order by some property.
        // For example, you cannot query SQL and just end the query with ORDER BY and not specifiying anything afterwards.
        // See the IEnumerable<T>.OrderBy extension methods for examples of odery by methods with no propery.

        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>
        (
            this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector,
            SortOrder sortOrder
        )
        {
            return sortOrder == SortOrder.Ascending
                ? source.OrderBy(keySelector) :
                source.OrderByDescending(keySelector);
        }

        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(
            this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector,
            IComparer<TKey> comparer,
            SortOrder sortOrder
        )
        {
            return sortOrder == SortOrder.Ascending ?
                source.OrderBy(keySelector, comparer) :
                source.OrderByDescending(keySelector, comparer);
        }
    }
}