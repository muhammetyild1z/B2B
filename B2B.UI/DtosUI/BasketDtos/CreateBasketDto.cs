using B2B.UI.DtosUI.ProductDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.UI.DtosUI.BasketDtos
{
    public class CreateBasketDto
    {
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }

      
       // public AppUser appUser { get; set; }
        public string UserID { get; set; }
       

        //public decimal ProductTotalPrice { get; set; }

        //public decimal BasketTotalPrice { get; set; }

       // public Productdimensions productdimensions { get; set; }
        public int productdimensionsID { get; set; }

        public int Count { get; set; }
      //  public ProductColor productColor { get; set; }
        public int productColorID { get; set; }
    }
}
