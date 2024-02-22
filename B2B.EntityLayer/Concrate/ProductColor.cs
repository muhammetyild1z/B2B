using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class ProductColor:Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductColorID { get; set; }
        [MaxLength(50)]
        public string ColorCode { get; set; }

        public Product product { get; set; }
        public int ProductID { get; set; }
    }
}
