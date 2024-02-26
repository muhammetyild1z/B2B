using B2B.API.Dtos.ProductDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.UI.DtosUI.BasketDtos
{
    public class CreateBasketDto
    {
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }

       
        public string UserID { get; set; }

      
        public int ProductID { get; set; }
    }
}
