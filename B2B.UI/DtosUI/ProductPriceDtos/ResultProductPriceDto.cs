using B2B.EntityLayer.Concrate;

namespace B2B.UI.DtosUI.ProductPriceDtos
{
    public class ResultProductPriceDto
    {
        public int PriceID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int ColorID { get; set; }
        public Color color { get; set; }

        public int DimensionsID { get; set; }
        public Dimensions dimensions { get; set; }
     //   public int Stock { get; set; }
        public decimal price { get; set; }
    }
}
