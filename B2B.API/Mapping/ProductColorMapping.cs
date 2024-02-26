using AutoMapper;
using B2B.API.Dtos.ProductColorDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Mapping
{
    public class ProductColorMapping:Profile
    {
        public ProductColorMapping()
        {
                CreateMap<ProductColor,CreateProductColorDto>().ReverseMap();
                CreateMap<ProductColor,UpdateProductColorDto>().ReverseMap();
                CreateMap<ProductColor,ResultProductColorDto>().ReverseMap();
        }
    }
}
