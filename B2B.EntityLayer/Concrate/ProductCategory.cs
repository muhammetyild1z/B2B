using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductCategoryID { get; set; }

        public Category category { get; set; }
        public int CategoryID { get; set; }

        public ParentSubCategory? parentSubCategory { get; set; }
        public int? ParentSubCategoryID { get; set; }

        public ChildSubCategory? ChildSubCategory { get; set; }
        public int? ChildSubCategoryID { get; set; }

        public int ProductID { get; set; }
        public Product product { get; set; }

    }
}
