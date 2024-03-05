using B2B.BusinessLayer.Abstract;
using B2B.DataAccessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.Graph.Models;


namespace B2B.BusinessLayer.Concrate
{
    public class ProductStockManager : IProductStockService
    {
        IProductStockDAL _productStock;

        public ProductStockManager(IProductStockDAL productStock)
        {
            _productStock = productStock;
        }

        public void TDelete(ProductStock entity)
        {
            _productStock.Delete(entity);
        }

        public ProductStock TGetByID(int id)
        {
            return _productStock.GetByID(id);
        }

        public List<ProductStock> TGetList()
        {
            return _productStock.GetList();
        }

        public Task<OperationResult> TInsertAsync(ProductStock entity)
        {
            try
            {
                return _productStock.InsertAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<OperationResult> TUpdateAsync(ProductStock entity, ProductStock unchanged)
        {
            try
            {
                return await _productStock.UpdateAsync(entity, unchanged);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
