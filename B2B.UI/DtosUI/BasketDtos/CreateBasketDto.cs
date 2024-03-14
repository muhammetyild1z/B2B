using B2B.UI.DtosUI.ProductDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.UI.DtosUI.BasketDtos
{
    public class CreateBasketDto
    {
    

        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int BasketID { get; set; }

        public int PriceID { get; set; }

        public string UserID { get; set; }

 
      

        public int Count { get; set; }
    }
}
