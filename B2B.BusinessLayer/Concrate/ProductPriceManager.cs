using B2B.BusinessLayer.Abstract;
using B2B.DataAccessLayer.Abstract;
using B2B.DataAccessLayer.Repositories;
using B2B.EntityLayer.Concrate;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.Concrate
{
    public class ProductPriceManager : IProductPriceService
    {
        IProductPriceDAL _productPriceDal;

        public ProductPriceManager(IProductPriceDAL productPriceDal)
        {
            _productPriceDal = productPriceDal;
        }

        public void TDelete(ProductPrice entity)
        {
            _productPriceDal.Delete(entity);
        }

        public ProductPrice TGetByID(int id)
        {
            return _productPriceDal.GetByID(id);
        }

        public ProductPrice TGetByIdIncludePrice(int priceId)
        {
            return _productPriceDal.GetByIdIncludePrice(priceId);
        }

        public List<ProductPrice> TGetIncludePriceList()
        {
            return _productPriceDal.GetIncludePriceList();
        }

        public List<ProductPrice> TGetList()
        {
            return _productPriceDal.GetList();
        }

        public async Task<OperationResult> TInsertAsync(ProductPrice entity)
        {
            try
            {
                return await _productPriceDal.InsertAsync(entity);
            }
            catch (Exception)
            {

                return OperationResult.Failure;
            }
        }

        public async Task<OperationResult> TUpdateAsync(ProductPrice entity, ProductPrice unchanged)
        {
            try
            {
                return await _productPriceDal.UpdateAsync(entity, unchanged);
            }
            catch (Exception)
            {

                return OperationResult.Failure;
            }
        }
    }
}
