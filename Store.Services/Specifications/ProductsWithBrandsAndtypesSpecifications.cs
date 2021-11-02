using System;
using System.Linq.Expressions;
using Store.Core.Entities;
using Store.Core.Specifications;

namespace Store.Services.Specifications
{
    public class ProductsWithBrandsAndtypesSpecifications : BaseSpecification<Product>
    {
        public ProductsWithBrandsAndtypesSpecifications(ProductSpecParams Productparams) : base(
              x =>
              (!Productparams.BrandId.HasValue || x.ProductBrandId == Productparams.BrandId)
              && (!Productparams.TypeId.HasValue || x.ProductTypeId == Productparams.TypeId)
        )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            // AddInclude("ProductType");//for thenInclude
            Applypaging(Productparams.PageSize * (Productparams.PageIndex - 1), Productparams.PageSize);
        }

        public ProductsWithBrandsAndtypesSpecifications(Expression<Func<Product, bool>> q) : base(q)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}