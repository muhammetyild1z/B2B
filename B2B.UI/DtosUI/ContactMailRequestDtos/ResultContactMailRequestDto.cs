using System.ComponentModel.DataAnnotations;

namespace B2B.UI.DtosUI.ContactMailRequestDtos
{
    public class ResultContactMailRequestDto
    {
        public int ContactMailRequestID { get; set; }
     
        public string Name { get; set; }
      
        public string Email { get; set; }
      
        public string Phone { get; set; }
   
        public string Message { get; set; }

        public string Subject { get; set; }
    }
}
