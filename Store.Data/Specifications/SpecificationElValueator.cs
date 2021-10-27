using System.Linq;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.Specifications;

namespace Store.Data.Specifications
{
    public class SpecificationElValueator<TEntity> where TEntity : EntityBase
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);//exam:p=>p.Id==id
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            query = spec.IncludeStrings.Aggregate(query,(current, include) =>current.Include(include));
            return query;
        }
    }
}