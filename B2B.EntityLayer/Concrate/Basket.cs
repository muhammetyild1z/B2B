﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class Basket : Base
    {
        public int BasketID { get; set; }

        public AppUser appUser { get; set; }
        public string UserID { get; set; }

        //public decimal ProductTotalPrice { get; set; }
        //public decimal BasketTotalPrice { get; set; }

        public ProductPrice productPrice { get; set; }
        public int PriceID { get; set; }

       // public Stock? stock { get; set; }
     //   public int? StockID { get; set; }


        public int Count { get; set; }


    }
}
