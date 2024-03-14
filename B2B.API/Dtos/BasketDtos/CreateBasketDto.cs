using B2B.API.Dtos.ProductDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.API.Dtos.BasketDtos
{
    public class CreateBasketDto
    {
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
     

     
        public string UserID { get; set; }

     
        public int PriceID { get; set; }


        public int Count { get; set; }
    }
}
