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
        IProductColorDAL _poductColor;

        public ProductColorManager(IProductColorDAL poductColor)
        {
            _poductColor = poductColor;
        }

        public void TDelete(ProductColor entity)
        {
            _poductColor.Delete (entity);   
        }

        public ProductColor TGetByID(int id)
        {
            return _poductColor.GetByID (id);
        }

        public List<ProductColor> TGetColorIncludeProducts()
        {
          return _poductColor.GetColorIncludeProducts();
        }

        public List<ProductColor> TGetList()
        {
           return _poductColor.GetList();
        }

        public async Task<OperationResult> TInsertAsync(ProductColor entity)
        {
            try
            {
                return await _poductColor.InsertAsync(entity);
            }
            catch (Exception)
            {

               return OperationResult.Failure;
            }
        }

        public async Task<OperationResult> TUpdateAsync(ProductColor entity, ProductColor unchanged)
        {
            try
            {
                return await _poductColor.UpdateAsync(entity, unchanged);
            }
            catch (Exception)
            {

                return OperationResult.Failure;
            }
        }
    }
}
