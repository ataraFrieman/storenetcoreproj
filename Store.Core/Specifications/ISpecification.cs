using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Store.Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        Expression<Func<T, object>> Orderby { get; }
        Expression<Func<T, object>> OrderbyDescending { get; }
        int Take { get; }
        int Skip { get; }

        bool IsPagingEnabled{ get; }

    }
}