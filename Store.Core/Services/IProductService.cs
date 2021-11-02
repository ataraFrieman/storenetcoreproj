using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Entities;
using Store.Core.Specifications;

namespace Store.Core.Services
{
    public interface IProductService
    {
       Task<IEnumerable<Product>> GetAllProductsAsync(ProductSpecParams Productparams);
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product productToBeUpdated, Product product);

        Task<IEnumerable<ProductBrand>> GetProductBrandsAsync();
        Task<IEnumerable<ProductType>> GetProductTypesAsync(); 
    }
}