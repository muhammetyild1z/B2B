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

        public List<Product> TGetList()
        {
            return _productDal.GetList();
        }

        public Product TGetProductByID(int id)
        {
            return _productDal.GetProductByID(id);
        }

        public async Task<OperationResult> TInsertAsync(Product entity)
        {
            return await _productDal.InsertAsync(entity);
        
        }

        public async Task<OperationResult> TUpdateAsync(Product entity, Product unchanged)
        {
            return await _productDal.UpdateAsync(entity, unchanged);
            
        }
    }
}
