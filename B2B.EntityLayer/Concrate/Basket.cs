﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class Basket:Base
    {
        public int BasketID { get; set; }

        public AppUser appUser { get; set; }
        public string UserID { get; set; }

        public Product product { get; set; }
        public int ProductID { get; set; }

  
    }
}