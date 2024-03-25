using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.EntityLayer.Concrate
{
    public class UserFavoriList
    {
        public int FavoriID { get; set; }

        public ProductPrice price { get; set; }
        public int priceID { get; set; }
        public AppUser appUser { get; set; }
        public string userID { get; set; }
        public DateTime createDate { get; set; }
    }
}
