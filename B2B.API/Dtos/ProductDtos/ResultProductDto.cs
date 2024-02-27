using System.ComponentModel.DataAnnotations;

namespace B2B.API.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
      
        public string ProductImage { get; set; }
    }
}
