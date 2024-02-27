using B2B.DataAccessLayer.Abstract;
using B2B.DataAccessLayer.Concrate;
using B2B.DataAccessLayer.Repositories;
using B2B.EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccessLayer.EntityFramework
{
    public class efHomeSliderRepository : GenericRepository<HomeSlider>, IHomeSliderDAL
    {
        private readonly B2B_Context _context;
        public efHomeSliderRepository(B2B_Context context) : base(context)
        {
            _context = context;
        }

        public HomeSlider GetHomeSliderByID(int id)
        {
           
                var homeSlider = _context.homeSliders.Where(x => x.SliderID == id).FirstOrDefault();
                return homeSlider;
            
           
           
        }

        public List<HomeSlider> GetHomeSlidersIncludeProduct()
        {
           return _context.homeSliders.Include(x=>x.product).ToList();
        }
    }
}
