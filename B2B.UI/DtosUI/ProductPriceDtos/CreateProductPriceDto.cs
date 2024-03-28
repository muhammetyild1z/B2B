namespace B2B.UI.DtosUI.ProductPriceDtos
{
    public class CreateProductPriceDto
    {
        public int ProductID { get; set; }


        public int ColorID { get; set; }


        public int DimensionsID { get; set; }

        public int Quantity { get; set; }

        public decimal price { get; set; }
    }
}
