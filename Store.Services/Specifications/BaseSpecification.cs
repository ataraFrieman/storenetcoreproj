using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Store.Core.Specifications;

namespace Store.Services.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }


        public Expression<Func<T, bool>> Criteria { get; }


        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public List<string> IncludeStrings { get; } = new List<string>();

        public Expression<Func<T, object>> Orderby { get; private set; }

        public Expression<Func<T, object>> OrderbyDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        //for all theninclude
        protected void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        protected void AddOrderby(Expression<Func<T, object>> orderbyExp)
        {
            Orderby = orderbyExp;
        }

         protected void AddOrderbyDescending(Expression<Func<T, object>> orderbyExpDescending)
        {
            OrderbyDescending= orderbyExpDescending;
        }

         protected void Applypaging(int take, int skip)
        {
            Take = take;
            Skip = skip;
            IsPagingEnabled = true;
        }
    }
}