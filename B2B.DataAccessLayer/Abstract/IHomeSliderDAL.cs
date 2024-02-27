﻿using B2B.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccessLayer.Abstract
{
    public interface IHomeSliderDAL:IGenericDal<HomeSlider>
    {
        HomeSlider GetHomeSliderByID(int id);
        List<HomeSlider> GetHomeSlidersIncludeProduct();
    }
}
