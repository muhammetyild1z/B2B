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
    public class ProductdimensionsManager : IProductdimensionsService
    {
        IProductDimensionsDAL _productdimensions;

        public ProductdimensionsManager(IProductDimensionsDAL productdimensions)
        {
            _productdimensions = productdimensions;
        }

        public void TDelete(Productdimensions entity)
        {
            _productdimensions.Delete(entity);
        }

        public Productdimensions TGetByID(int id)
        {
           return _productdimensions.GetByID(id);
        }

        public List<Productdimensions> TGetList()
        {
           return _productdimensions.GetList();
        }

        public List<Productdimensions> TGetProductDimensionsInclude()
        {
            return _productdimensions.GetProductDimensionsInclude();
        }

        public async Task<OperationResult> TInsertAsync(Productdimensions entity)
        {
            try
            {
                return await _productdimensions.InsertAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OperationResult> TUpdateAsync(Productdimensions entity, Productdimensions unchanged)
        {
            try
            {
                return await _productdimensions.UpdateAsync(entity, unchanged);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
