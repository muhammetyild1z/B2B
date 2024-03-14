using B2B.UI.DtosUI.ProductDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.UI.DtosUI.BasketDtos
{
    public class UpdateBasketDto
    {
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int BasketID { get; set; }

        public AppUser appUser { get; set; }
        public string UserID { get; set; }

        //public decimal ProductTotalPrice { get; set; }

        //public decimal BasketTotalPrice { get; set; }
        public ProductPrice productPrice { get; set; }
        public int PriceID { get; set; }


        public int Count { get; set; }
    }
}
