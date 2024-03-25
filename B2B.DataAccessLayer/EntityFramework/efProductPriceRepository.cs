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
    public class efProductPriceRepository : GenericRepository<ProductPrice> , IProductPriceDAL
    {
        private readonly B2B_Context _context;

        public efProductPriceRepository(B2B_Context context) : base(context)
        {
            _context = context;
        }

        public ProductPrice GetByIdIncludePrice(/*int priceId*/ int productid)
        {
            if (productid == 0)
            {
                return null;
            }
            return _context.productPrices.Include(x => x.Product).Include(x => x.dimensions).Include(x => x.color).First(x=>x.ProductID== productid);
        }

        public List<ProductPrice> GetIncludePriceList()
        {
            return _context.productPrices.Include(x => x.Product).Include(x=>x.dimensions).Include(x=>x.color).ToList();
        }
    }
}
