using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Store.Api.Helpers;
using Store.Api.Resources;
using Store.Core.Entities;

namespace Store.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Product, ProductResource>()
            .ForMember(p => p.ProductBrand, o => o.MapFrom(b => b.ProductBrand.Name))
            .ForMember(p => p.ProductType, o => o.MapFrom(b => b.ProductType.Name))
            .ForMember(p => p.PicturUrl, o => o.MapFrom<ProductUrlResolver>());

            
            CreateMap<ProductType, ProductTypeResource>();
            CreateMap<ProductBrand, ProductBrandResource>();



            // Resource to Domain
            CreateMap<ProductResource,Product >();
            CreateMap<ProductTypeResource,ProductType >();
            CreateMap<ProductBrandResource,ProductBrand >();


        }
    }
}