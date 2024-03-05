using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class ProductStock:Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductStockID { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Stock { get; set; }
      

        public int ProductID { get; set; }
        public Product product { get; set; }
    }
}
