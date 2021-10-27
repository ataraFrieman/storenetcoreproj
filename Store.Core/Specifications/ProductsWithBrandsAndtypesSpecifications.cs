using System;
using System.Linq.Expressions;
using Store.Core.Entities;

namespace Store.Core.Specifications
{
    public class ProductsWithBrandsAndtypesSpecifications: BaseSpecification<Product>
    {
        public ProductsWithBrandsAndtypesSpecifications()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            // AddInclude("ProductType");//for thenInclude

        }

        public ProductsWithBrandsAndtypesSpecifications(Expression<Func<Product, bool>> q ) : base(q)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}