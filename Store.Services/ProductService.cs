using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core;
using Store.Core.Entities;
using Store.Core.Services;
using Store.Core.Specifications;

namespace Store.Services
{
    public class ProductService : IProductService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var spec = new ProductsWithBrandsAndtypesSpecifications();
            return await _unitOfWork.Products.ListAsync(spec);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var spec = new ProductsWithBrandsAndtypesSpecifications(x=>x.Id == id);

            return await _unitOfWork.Products.GetEntityWithSpec(spec);
        }


        public async Task<Product> CreateProductAsync(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CommitAsync();
            return product;
        }

        public async Task DeleteProductAsync(Product product)
        {
            _unitOfWork.Products.Remove(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Product> UpdateProductAsync(Product productToBeUpdated, Product product)
        {
            productToBeUpdated.Name = product.Name;
            await _unitOfWork.CommitAsync();
            return productToBeUpdated;
        }

        public async Task<IEnumerable<ProductBrand>> GetProductBrandsAsync()
        {
            return await _unitOfWork.Products.GetProductBrandsAsync();
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            return await _unitOfWork.Products.GetProductTypesAsync();
        }
    }
}