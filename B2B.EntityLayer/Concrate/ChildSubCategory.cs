﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class ChildSubCategory : Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChildSubCategoryID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }


        
    }
}
