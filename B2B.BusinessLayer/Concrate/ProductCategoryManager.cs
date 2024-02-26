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
    public class ProductCategoryManager : IProductCategoryService
    {
        IProductCategoriesDAL _productCategory;

        public ProductCategoryManager(IProductCategoriesDAL productCategory)
        {
            _productCategory = productCategory;
        }

        public void TDelete(ProductCategory entity)
        {
            _productCategory.Delete(entity);
        }

        public List<ProductCategory> TGetAllCategoriesInclude()
        {
          return _productCategory.GetAllCategoriesInclude();
        }

        public ProductCategory TGetByID(int id)
        {
            return _productCategory.GetByID(id);
        }

        public List<ProductCategory> TGetList()
        {
           return _productCategory.GetList();
        }

        public ProductCategory TGetProductCategoryByID(int id)
        {
               return _productCategory.GetProductCategoryByID(id);
        }

        public async Task<OperationResult> TInsertAsync(ProductCategory entity)
        {
            return await _productCategory.InsertAsync(entity); 
           
        }

        public async Task<OperationResult> TUpdateAsync(ProductCategory entity, ProductCategory unchanged)
        {
            return await _productCategory.UpdateAsync(entity, unchanged);
            
        }
    }
}
