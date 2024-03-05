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
    public class IColorManager : IColorService
    {
        IColorDal _colorDal;

        public IColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void TDelete(Color entity)
        {
            _colorDal.Delete(entity);
        }

        public Color TGetByID(int id)
        {
            return _colorDal.GetByID(id);
        }

        public List<Color> TGetList()
        {
            return _colorDal.GetList();
        }

        public async Task<OperationResult> TInsertAsync(Color entity)
        {
            try
            {
               await _colorDal.InsertAsync(entity);
                return OperationResult.Success;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OperationResult> TUpdateAsync(Color entity, Color unchanged)
        {
            try
            {
                await _colorDal.UpdateAsync(entity, unchanged);
                return OperationResult.Success;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
