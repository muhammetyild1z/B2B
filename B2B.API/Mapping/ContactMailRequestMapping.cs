using AutoMapper;
using B2B.API.Dtos.ContactMailRequestDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Mapping
{
    public class ContactMailRequestMapping:Profile
    {
        public ContactMailRequestMapping()
        {
            CreateMap<ContactMailRequest, ResultContactMailRequestDto>().ReverseMap();
            CreateMap<ContactMailRequest, UpdateContactMailRequestDto>().ReverseMap();
            CreateMap<ContactMailRequest, CreateContactMailRequestDto>().ReverseMap();
        }
    }
}
