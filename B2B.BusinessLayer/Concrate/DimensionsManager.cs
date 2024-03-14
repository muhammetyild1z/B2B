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
    public class DimensionsManager : IDimensionsService
    {
        IDimensionsDAL _dimensionsDal;

        public DimensionsManager(IDimensionsDAL dimensionsDal)
        {
            _dimensionsDal = dimensionsDal;
        }

        public void TDelete(Dimensions entity)
        {
            _dimensionsDal.Delete(entity);
        }

        public Dimensions TGetByID(int id)
        {
           return _dimensionsDal.GetByID(id);
        }

        public List<Dimensions> TGetList()
        {
           return _dimensionsDal.GetList();
        }

        public async Task<OperationResult> TInsertAsync(Dimensions entity)
        {
            try
            {
                return await _dimensionsDal.InsertAsync(entity);
            }
            catch (Exception)
            {

                return OperationResult.Failure;
            }
        }

        public async Task<OperationResult> TUpdateAsync(Dimensions entity, Dimensions unchanged)
        {
            try
            {
                return await _dimensionsDal.UpdateAsync(entity, unchanged);
            }
            catch (Exception)
            {

                return OperationResult.Failure;
            }
        }
    }
}
