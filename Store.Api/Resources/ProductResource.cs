using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Resources
{
    public class ProductResource:EntityBaseResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PicturUrl { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}