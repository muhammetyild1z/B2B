using System.Drawing;

namespace B2B.EntityLayer.Concrate
{
    public class Stock:Base
    {
        public int StockID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int ColorID { get; set; }
        public Color color { get; set; }

        public int DimensionsID { get; set; }
        public Dimensions dimensions { get; set; }

        public int Quantity { get; set; }
    }
}
