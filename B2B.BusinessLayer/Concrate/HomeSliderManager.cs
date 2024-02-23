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
    public class HomeSliderManager : IHomeSliderService
    {
        IHomeSliderDAL _homeslider;

        public HomeSliderManager(IHomeSliderDAL homeslider)
        {
            _homeslider = homeslider;
        }

        public void TDelete(HomeSlider entity)
        {
            _homeslider.Delete(entity);
        }

        public HomeSlider TGetByID(int id)
        {
           return _homeslider.GetByID(id);
        }

        public Task<List<HomeSlider>> TGetListAsync()
        {
           return _homeslider.GetListAsync();
        }

        public async Task<OperationResult> TInsertAsync(HomeSlider entity)
        {
           await _homeslider.InsertAsync(entity);
            return OperationResult.Success;
        }

        public async Task<OperationResult> TUpdateAsync(HomeSlider entity, HomeSlider unchanged)
        {
            await _homeslider.UpdateAsync(entity, unchanged);
            return OperationResult.Success;
        }
    }
}
