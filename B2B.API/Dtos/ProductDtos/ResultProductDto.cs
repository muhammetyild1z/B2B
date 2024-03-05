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
        public int Product_ID { get; set; }
        public string ProductImage { get; set; }

        public string? ProductImage1 { get; set; }

        public string? ProductImage2 { get; set; }

        public string? ProductImage3 { get; set; }
    }
}
