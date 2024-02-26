using AutoMapper;
using B2B.API.Dtos.HomeSliderDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Mapping
{
    public class HomeSliderMapping:Profile
    {
        public HomeSliderMapping()
        {
            CreateMap<HomeSlider,CreateHomeSliderDto>().ReverseMap();
            CreateMap<HomeSlider,UpdateHomeSliderDto>().ReverseMap();
            CreateMap<HomeSlider,ResultHomeSliderDto>().ReverseMap();
        }
    }
}
