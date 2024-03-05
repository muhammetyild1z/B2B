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
    public class efProductdimensionsRepository : GenericRepository<Productdimensions>, IProductDimensionsDAL
    {
        private readonly B2B_Context _context;

        public efProductdimensionsRepository(B2B_Context context) : base(context)
        {
            _context=context;
        }

        public List<Productdimensions> GetProductDimensionsInclude()
        {
            return _context.productdimensions.Include(x => x.dimensions).ToList();
        }
    }
}
