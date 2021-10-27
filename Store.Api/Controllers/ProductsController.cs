using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Resources;
using Store.Core.Entities;
using Store.Core.Services;

namespace Store.Api.Controllers
{
     public class ProductsController : BaseApiController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {

            var products = await _productService.GetAllProductsAsync();
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return Ok(productResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            var productResources = _mapper.Map<Product, ProductResource>(product);
            return Ok(productResources);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductBrands()
        {
            var productsBrands = await _productService.GetProductBrandsAsync();
            var productsBrandsResource = _mapper.Map<IEnumerable<ProductBrand>, IEnumerable<ProductBrandResource>>(productsBrands);
            return Ok(productsBrandsResource);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        {
            var productsTypes = await _productService.GetProductTypesAsync();
            var productsTypeResource = _mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeResource>>(productsTypes);
            return Ok(productsTypeResource);
        }
        // [HttpGet("{id}")]
        // public string GetProductById(int id)
        // {
        //     return "one product";
        // }
    }
}