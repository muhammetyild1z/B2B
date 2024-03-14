using B2B.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccessLayer.Abstract
{
    public interface IBasketDAL:IGenericDal<Basket>
    {
        Basket GetBasketByID(int id);
      List<Basket> GetIncludeAllUserBasket();
    }
}
