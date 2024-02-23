using B2B.DataAccessLayer.Abstract;
using B2B.DataAccessLayer.Concrate;
using B2B.DataAccessLayer.Repositories;
using B2B.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccessLayer.EntityFramework
{
    public class efHomeSliderRepository : GenericRepository<HomeSlider>, IHomeSliderDAL
    {
        public efHomeSliderRepository(B2B_Context context) : base(context)
        {
        }
    }
}
