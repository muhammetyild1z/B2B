using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class Productdimensions
    {
        public int ProductdimensionsID { get; set; }

     
        public Product product { get; set; }
        public int ProductID { get; set; }
        public Dimensions dimensions { get; set; }
        public int DimensionsID { get; set; }

    }
}
