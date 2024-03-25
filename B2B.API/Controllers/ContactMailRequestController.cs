using AutoMapper;
using B2B.API.Dtos.ContactDtos;
using B2B.API.Dtos.ContactMailRequestDtos;
using B2B.BusinessLayer.Abstract;
using B2B.BusinessLayer.FluentValidation;
using B2B.EntityLayer.Concrate;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace B2B.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ContactMailRequestController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IContactMailRequestService _contactMailRequestService;

        public ContactMailRequestController(IMapper mapper, IContactMailRequestService contactMailRequestService)
        {
            _mapper = mapper;
            _contactMailRequestService = contactMailRequestService;
        }

        [HttpGet("AllGetContactMailRequest")]
        public IActionResult AllGetContactMailRequest()
        {
            var contactValue = _contactMailRequestService.TGetList();
            return Ok(_mapper.Map<List<ResultContactMailRequestDto>>(contactValue));
        }

        [HttpPost("CreateContactMailRequest")]
        public async Task<IActionResult> CreateContactMailRequest(CreateContactMailRequestDto createContactMailRequestDto)
        {
            ContactMailRequestValidation cmv = new ContactMailRequestValidation();
            var validationResult = cmv.Validate(_mapper.Map<ContactMailRequest>(createContactMailRequestDto));
            if (validationResult.IsValid)
            {
                var result = _contactMailRequestService.TInsertAsync(_mapper.Map<ContactMailRequest>(createContactMailRequestDto));
                if (result.IsCompleted)
                {
                    return Ok();
                }

            }
         
            return BadRequest();
        }

        [HttpPut("UpdateContactMailRequest")]
        public IActionResult UpdateContactMailRequest(UpdateContactMailRequestDto updateContactMailRequestDto)
        {

            if (updateContactMailRequestDto.ContactMailRequestID != null)
            {
                var unchangedContact = _contactMailRequestService.TGetByID(updateContactMailRequestDto.ContactMailRequestID);
                if (unchangedContact != null)
                {
                    var result = _contactMailRequestService.TUpdateAsync(_mapper.Map<ContactMailRequest>(updateContactMailRequestDto), unchangedContact);
                    if (result.IsCompleted)
                    {
                        return Ok();
                    }
                    return BadRequest();
                }
            }
            return NotFound();

        }


        [HttpDelete("DeleteContactMailRequest{id}")]
        public IActionResult DeleteContactMailRequest(int id)
        {
            if (id != 0)
            {
                var removedContact = _contactMailRequestService.TGetByID(id);
                if (removedContact != null)
                {
                    _contactMailRequestService.TDelete(removedContact);
                    return Ok();
                }
              
            }
            return NotFound();
        }
    }

}

