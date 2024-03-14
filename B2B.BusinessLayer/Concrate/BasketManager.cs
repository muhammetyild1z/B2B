using B2B.BusinessLayer.Abstract;
using B2B.DataAccessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.Concrate
{
    public class BasketManager : IBasketService
    {
        IBasketDAL _basketDal;

        public BasketManager(IBasketDAL basketDal)
        {
            _basketDal = basketDal;
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public Basket TGetBasketByID(int id)
        {
            return _basketDal.GetBasketByID(id);
        }

        public Basket TGetByID(int id)
        {
            return _basketDal.GetByID(id);
        }

        public List<Basket> TGetIncludeAllUserBasket()
        {
            return _basketDal.GetIncludeAllUserBasket();
        }

        public List<Basket> TGetList()
        {
            return _basketDal.GetList();
        }

        public async Task<OperationResult> TInsertAsync(Basket entity)
        {
            try
            {

                return await _basketDal.InsertAsync(entity);

            }
            catch (Exception ex)
            {

                return OperationResult.Failure;
            }
        }

        public async Task<OperationResult> TUpdateAsync(Basket entity, Basket unchanged)
        {
            try
            {

                return await _basketDal.UpdateAsync(entity, unchanged);

            }
            catch (Exception ex)
            {

                return OperationResult.Failure;
            }

        }
    }
}
