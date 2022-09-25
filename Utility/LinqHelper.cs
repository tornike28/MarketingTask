using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class LinqHelper
    {
        public static IQueryable<TSource> WhereIfHas<TSource>(
             this IQueryable<TSource> source,
              object value,
              Expression<Func<TSource, bool>> predicate
          ) where TSource : class
        {
            if (value != null)
            {
                if (value is string)
                {
                    if (string.IsNullOrEmpty((string)value)) return source;
                    value = ((string)value).Trim().ToLower();
                }

                return source.Where(predicate);
            }
            return source;
        }
    }
}
