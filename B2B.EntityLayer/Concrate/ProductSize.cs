using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class ProductSize
    {
        public int ProductSizeID{ get; set; }
        public int ProductID { get; set; }
        public Product product { get; set; }

        public int DimensionsID { get; set; }
        public Dimensions dimensions { get; set; }
    }
}
