using AutoMapper;
using B2B.API.Dtos.ContactDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact,ResultContactDto>().ReverseMap();
            CreateMap<Contact,UpdateContactDto>().ReverseMap();
            CreateMap<Contact,CreateContactDto>().ReverseMap();
        }
    }
}
