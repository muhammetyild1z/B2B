using AutoMapper;
using B2B.API.Dtos.ChildSubCategoryDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Mapping
{
    public class ChildSubCategoryMapping:Profile
    {
        public ChildSubCategoryMapping()
        {
            CreateMap<ChildSubCategory,CreateChildSubCategoryDto>().ReverseMap();
            CreateMap<ChildSubCategory,UpdateChildSubCategoryDto>().ReverseMap();
            CreateMap<ChildSubCategory,ResultChildSubCategoryDto>().ReverseMap();
        }
    }
}
