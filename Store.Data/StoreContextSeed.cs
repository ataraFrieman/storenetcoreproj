using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Store.Core.Entities;

namespace Store.Data
{
     public class StoreContextSeed
    {
        public async static Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandData = File.ReadAllText("../MyMusic.Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                    foreach (var newBrand in brands)
                    {
                        context.ProductBrands.Add(newBrand);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typeData = File.ReadAllText("../MyMusic.Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                    foreach (var newType in types)
                    {
                        context.ProductTypes.Add(newType);
                    }
                    await context.SaveChangesAsync();
                }
                
                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("../MyMusic.Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);
                    foreach (var newProduct in products)
                    {
                        context.Products.Add(newProduct);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex){
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}