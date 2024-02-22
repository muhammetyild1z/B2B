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

        public Basket TGetByID(int id)
        {
            return _basketDal.GetByID(id);
        }

        public Task<List<Basket>> TGetListAsync()
        {
           return _basketDal.GetListAsync();
        }

        public async Task<OperationResult> TInsertAsync(Basket entity)
        {
            await _basketDal.InsertAsync(entity);
            return OperationResult.Success;
        }

        public async Task<OperationResult> TUpdateAsync(Basket entity, Basket unchanged)
        {
            await _basketDal.UpdateAsync(entity, unchanged);    
            return OperationResult.Success;
        }
    }
}
