using AutoMapper;
using B2B.API.Dtos.ProductPriceDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Mapping
{
    public class ProductPriceMapping:Profile
    {
        public ProductPriceMapping()
        {
                CreateMap<ProductPrice , ResultProductPriceDto>().ReverseMap();
                CreateMap<ProductPrice , CreateProductPriceDto>().ReverseMap();
        }
    }
}
