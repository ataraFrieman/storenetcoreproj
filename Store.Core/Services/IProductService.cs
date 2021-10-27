using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Entities;

namespace Store.Core.Services
{
    public interface IProductService
    {
       Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product productToBeUpdated, Product product);

        Task<IEnumerable<ProductBrand>> GetProductBrandsAsync();
        Task<IEnumerable<ProductType>> GetProductTypesAsync(); 
    }
}