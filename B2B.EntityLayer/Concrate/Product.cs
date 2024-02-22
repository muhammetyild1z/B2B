using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class Product : Base
    {
        public int Product_ID { get; set; }
        public decimal ProductPrice { get; set; }
        [MaxLength(300)]
        public string ProductDescription { get; set; }
        [MaxLength(100)]
        public string ProductImage { get; set; }
     


        // public Category category { get; set; }
        //public int Category_ID { get; set; }

        //public ProductColor productColor { get; set; }
        // public int ProductColor_ID { get; set; }
    }
}
