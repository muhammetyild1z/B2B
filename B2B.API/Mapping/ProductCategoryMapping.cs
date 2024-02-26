using AutoMapper;
using B2B.API.Dtos.ProductCategoryDtos;
using B2B.API.Dtos.ProductDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Mapping
{
    public class ProductCategoryMapping:Profile
    {
        public ProductCategoryMapping()
        {
                CreateMap<ProductCategory, CreateProductCategoryDto>().ReverseMap();
                CreateMap<ProductCategory, UpdateProductCategoryDto>().ReverseMap();
                CreateMap<ProductCategory, ResultProductCategoryDto>().ReverseMap();
        }
    }
}
