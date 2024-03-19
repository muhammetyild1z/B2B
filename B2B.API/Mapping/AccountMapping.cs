using AutoMapper;
using B2B.API.Dtos.AccountDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Mapping
{
    public class AccountMapping:Profile
    {
        public AccountMapping()
        {
            CreateMap<AppUser, SignInDto>().ReverseMap();
            CreateMap<AppUser, SignUpDto>().ReverseMap();
        }
    }
}
