using AutoMapper;
using B2B.API.Dtos.ParentSubCategoryDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Mapping
{
    public class ParentSubCategoryMapping:Profile
    {
        public ParentSubCategoryMapping()
        {
            CreateMap<ParentSubCategory, ResultParentSubCategoryDto>().ReverseMap();
            CreateMap<ParentSubCategory, CreateParentSubCategoryDto>().ReverseMap();
            CreateMap<ParentSubCategory, UpdateParentSubCategoryDto>().ReverseMap();
        }
    }
}
