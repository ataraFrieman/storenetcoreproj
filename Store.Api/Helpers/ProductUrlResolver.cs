using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Api.Resources;
using Store.Core.Entities;

namespace Store.Api.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductResource, string>
    {
        public IConfiguration _config { get; }
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }


        public string Resolve(Product source, ProductResource destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PicturUrl))
            {
                return _config["ApiUrl"] + source.PicturUrl;
            }
            return null;
        }
    }
}