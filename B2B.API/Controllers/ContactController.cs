using AutoMapper;
using B2B.API.Dtos.ContactDtos;
using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;


namespace B2B.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public ContactController(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        [HttpGet("AllGetContact")]
        public IActionResult AllGetContact()
        {
            var contactValue = _contactService.TGetList();
            return Ok(_mapper.Map<List<ResultContactDto>>(contactValue));
        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var result = _contactService.TInsertAsync(_mapper.Map<Contact>(createContactDto));

            if (result.IsCompleted)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("UpdateContact")]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {

            if (updateContactDto.ContactID != null)
            {
                var unchangedContact = _contactService.TGetByID(updateContactDto.ContactID);
                if (unchangedContact != null)
                {
                    var result = _contactService.TUpdateAsync(_mapper.Map<Contact>(updateContactDto), unchangedContact);
                    if (result.IsCompleted)
                    {
                        return Ok();
                    }
                    return BadRequest();
                }
            }
            return NotFound();

        }


        [HttpDelete("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            if (id!=0)
            {
              var removedContact=  _contactService.TGetByID(id);
                if (removedContact != null)
                {
                    _contactService.TDelete(removedContact);
                    return Ok();
                }
              
            }
            return NotFound();
        }
    }


}

