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
    public class ProductColorManager : IProductColorService
    {
        IProductColorDAL _productColor;

        public ProductColorManager(IProductColorDAL productColor)
        {
            _productColor = productColor;
        }

        public void TDelete(ProductColor entity)
        {
            _productColor.Delete(entity);
        }

        public ProductColor TGetByID(int id)
        {
           return _productColor.GetByID(id);    
        }

        public Task<List<ProductColor>> TGetListAsync()
        {
           return _productColor.GetListAsync();
        }

        public async Task<OperationResult> TInsertAsync(ProductColor entity)
        {
           await _productColor.InsertAsync(entity);
            return OperationResult.Success;
        }

        public async Task<OperationResult> TUpdateAsync(ProductColor entity, ProductColor unchanged)
        {
           await _productColor.UpdateAsync(entity, unchanged);
            return OperationResult.Success;
        }
    }
}
