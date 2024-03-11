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
        public int ProductID { get; set; }
        [MaxLength(100)]
        public string ProductName { get; set; }
       // public decimal ProductPrice { get; set; }
        [MaxLength(600)]
        public string ProductDescription { get; set; }
        [MaxLength(1000)]
        public string ProductUseGuide { get; set; }
        [MaxLength(100)]
        public string ProductImage { get; set; }
        [MaxLength(100)]
        public string? ProductImage1 { get; set; }
        [MaxLength(100)]
        public string? ProductImage2 { get; set; }
        [MaxLength(100)]
        public string? ProductImage3 { get; set; }





        //public Category category { get; set; }
        //public int Category_ID { get; set; }

        //public ProductColor productColor { get; set; }
        //public int ProductColor_ID { get; set; }
    }
}
