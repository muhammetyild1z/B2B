using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class ProductColor:Base
    {
        public int ProductColorID { get; set; }

        public int productID { get; set; }
        public Product product { get; set; }  
        
        public int ColorID { get; set; }
        public Color color { get; set; }
    }
}
