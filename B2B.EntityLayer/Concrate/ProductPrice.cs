using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class ProductPrice
    {
        public int PriceID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int ColorID { get; set; }
        public Color color { get; set; }

        public int DimensionsID { get; set; }
        public Dimensions dimensions { get; set; }

        public int? StockID { get; set; }
        public Stock? stock { get; set; }

        public decimal price { get; set; }
    }
}
