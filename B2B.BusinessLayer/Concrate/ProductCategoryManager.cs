using B2B.BusinessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.Concrate
{
    public class ProductCategoryManager : IProductCategoryService
    {
        IProductCategoryService _productCategory;

        public ProductCategoryManager(IProductCategoryService productCategory)
        {
            _productCategory = productCategory;
        }

        public void TDelete(ProductCategory entity)
        {
            _productCategory.TDelete(entity);
        }

        public ProductCategory TGetByID(int id)
        {
            return _productCategory.TGetByID(id);
        }

        public Task<List<ProductCategory>> TGetListAsync()
        {
           return _productCategory.TGetListAsync();
        }

        public async Task<OperationResult> TInsertAsync(ProductCategory entity)
        {
           await _productCategory.TInsertAsync(entity); 
            return OperationResult.Success;
        }

        public async Task<OperationResult> TUpdateAsync(ProductCategory entity, ProductCategory unchanged)
        {
            await _productCategory.TUpdateAsync(entity, unchanged);
            return OperationResult.Success;
        }
    }
}
