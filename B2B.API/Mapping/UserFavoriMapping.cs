using AutoMapper;
using B2B.API.Dtos.UserFavoriDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Mapping
{
    public class UserFavoriMapping:Profile
    {
        public UserFavoriMapping()
        {
                CreateMap<UserFavoriList, CreateFavoriDto>().ReverseMap();
                CreateMap<UserFavoriList, ResultListFavoriDto>().ReverseMap();
        }
    }
}
