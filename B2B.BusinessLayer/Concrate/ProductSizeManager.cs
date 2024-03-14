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
    public class ProductSizeManager : IProductSizeService
    {
        IProductSizeDAL _productSizeDal;

        public ProductSizeManager(IProductSizeDAL productSizeDal)
        {
            _productSizeDal = productSizeDal;
        }

        public void TDelete(ProductSize entity)
        {
            _productSizeDal.Delete(entity);
        }

        public ProductSize TGetByID(int id)
        {
            return _productSizeDal.GetByID(id);
        }

        public List<ProductSize> TGetList()
        {
            return _productSizeDal.GetList();
        }

        public async Task<OperationResult> TInsertAsync(ProductSize entity)
        {
            try
            {
                return await _productSizeDal.InsertAsync(entity);
            }
            catch (Exception)
            {

                return OperationResult.Failure;
            }
        }

        public async Task<OperationResult> TUpdateAsync(ProductSize entity, ProductSize unchanged)
        {
            try
            {
                return await _productSizeDal.UpdateAsync(entity, unchanged);
            }
            catch (Exception)
            {

                return OperationResult.Failure;
            }
        }
    }
}
