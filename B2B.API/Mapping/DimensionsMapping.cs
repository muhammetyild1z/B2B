using AutoMapper;
using B2B.API.Dtos.DimensionsDto;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Mapping
{
    public class DimensionsMapping : Profile
    {
        public DimensionsMapping()
        {
            CreateMap<Dimensions, ResultDimensionsDto>().ReverseMap();
        }
    }
}
