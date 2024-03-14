using AutoMapper;
using B2B.API.Dtos.ColorDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Mapping
{
    public class ColorMapping:Profile
    {
        public ColorMapping()
        {
                CreateMap<Color,ResultColorDto>().ReverseMap();
        }
    }
}
