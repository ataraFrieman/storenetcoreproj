using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.Repositories;

namespace Store.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(StoreContext context)
            : base(context)
        { }


        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await StoreContext.Products
            .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .ToListAsync();
        }


        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await StoreContext.Products
             .Include(p => p.ProductBrand)
            .Include(p => p.ProductType)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProductBrand>> GetProductBrandsAsync()
        {
            return await StoreContext.ProductBrands.ToListAsync();
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            return await StoreContext.ProductTypes.ToListAsync();
        }

        private StoreContext StoreContext
        {
            get { return Context as StoreContext; }
        }
    }
}