using System.ComponentModel.DataAnnotations;

namespace B2B.API.Dtos.ContactDtos
{
    public class UpdateContactDto
    {
        public int ContactID { get; set; }
       
        public string? ContactDesc { get; set; }
      
        public string ContactAdress { get; set; }
      
        public string ContactPhone1 { get; set; }
      
       // public string? ContactPhone2 { get; set; }
     
        public string ContactMail1 { get; set; }
     
      //  public string? ContactMail2 { get; set; }
    }
}
