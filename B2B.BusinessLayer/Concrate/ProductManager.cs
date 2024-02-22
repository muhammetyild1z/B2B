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
    public class ProductManager : IProductService
    {
        IProductDAL _productDal;

        public ProductManager(IProductDAL productDal)
        {
            _productDal = productDal;
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetByID(int id)
        {
          return _productDal.GetByID(id);   
        }

        public Task<List<Product>> TGetListAsync()
        {
            return _productDal.GetListAsync();
        }

        public async Task<OperationResult> TInsertAsync(Product entity)
        {
            await _productDal.InsertAsync(entity);
            return OperationResult.Success; 
        }

        public async Task<OperationResult> TUpdateAsync(Product entity, Product unchanged)
        {
            await _productDal.UpdateAsync(entity, unchanged);
            return OperationResult.Success; 
        }
    }
}
