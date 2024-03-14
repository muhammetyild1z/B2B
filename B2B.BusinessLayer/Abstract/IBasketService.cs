using B2B.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
        Basket TGetBasketByID(int id);
        List<Basket> TGetIncludeAllUserBasket();
    }
}
