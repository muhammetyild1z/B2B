﻿using B2B.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.Abstract
{
    public interface IProductColorService:IGenericService<ProductColor>
    {
        ProductColor TGetProductColorByID(int id);
        List<ProductColor> TGetProductColorInclude();
    }
}
