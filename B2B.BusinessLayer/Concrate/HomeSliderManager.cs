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

        public HomeSlider TGetHomeSliderByID(int id)
        {
              return _homeslider.GetHomeSliderByID(id);
        }

        public List<HomeSlider> TGetHomeSlidersIncludeProduct()
        {
           return _homeslider.GetHomeSlidersIncludeProduct();
        }

        public List<HomeSlider> TGetList()
        {
           return _homeslider.GetList();
        }

        public async Task<OperationResult> TInsertAsync(HomeSlider entity)
        {
            return await _homeslider.InsertAsync(entity);
           
        }

        public async Task<OperationResult> TUpdateAsync(HomeSlider entity, HomeSlider unchanged)
        {
            return await _homeslider.UpdateAsync(entity, unchanged);
           
        }
    }
}
