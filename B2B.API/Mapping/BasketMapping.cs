using AutoMapper;
using B2B.API.Dtos.BasketDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Mapping
{
    public class BasketMapping:Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket, UpdateBasketDto>().ReverseMap();
            CreateMap<Basket, ResultBasketDto>().ReverseMap();
            CreateMap<Basket, CreateBasketDto>().ReverseMap();
        }
    }
}
