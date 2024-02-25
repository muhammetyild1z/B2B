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
    public class efProductColorRepository : GenericRepository<ProductColor>, IProductColorDAL
    {
        private readonly B2B_Context _context;
        public efProductColorRepository(B2B_Context context) : base(context)
        {
            _context = context;
        }

        public ProductColor GetProductColorByID(int id)
        {
            var productColor = _context.productColors.Where(x=>x.ProductColorID == id).FirstOrDefault();
            return productColor;
        }
    }
}
