using B2B.EntityLayer.Concrate;

namespace B2B.API.Dtos.ProductPriceDtos
{
    public class CreateProductPriceDto
    {
        public int ProductID { get; set; }
      

        public int ColorID { get; set; }
       

        public int DimensionsID { get; set; }

        public int Stock { get; set; }

        public decimal price { get; set; }
    }
}
