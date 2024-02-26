﻿using B2B.API.Dtos.ProductDtos;
using B2B.EntityLayer.Concrate;

namespace B2B.UI.DtosUI.BasketDtos { 
    public class ResultBasketDto
    {
        public int BasketID { get; set; }

        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }

        public AppUser appUser { get; set; }
        public string UserID { get; set; }

        public ResultProductDto product { get; set; }
        public int ProductID { get; set; }
    }
}
