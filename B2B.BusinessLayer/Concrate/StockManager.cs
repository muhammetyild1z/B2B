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
    public class StockManager : IStockService
    {
        IStockDAL _stockDal;

        public StockManager(IStockDAL stockDal)
        {
            _stockDal = stockDal;
        }

        public void TDelete(Stock entity)
        {
            _stockDal.Delete(entity);
        }

        public Stock TGetByID(int id)
        {
           return _stockDal.GetByID(id);
        }

        public List<Stock> TGetList()
        {
           return _stockDal.GetList();
        }

        public async Task<OperationResult> TInsertAsync(Stock entity)
        {
            try
            {
                return await _stockDal.InsertAsync(entity);
            }
            catch (Exception)
            {

                return OperationResult.Failure;
            }
        }

        public async Task<OperationResult> TUpdateAsync(Stock entity, Stock unchanged)
        {
            try
            {
                return await _stockDal.UpdateAsync(entity, unchanged);
            }
            catch (Exception)
            {

                return OperationResult.Failure;
            }
        }
    }
}
