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
    public class efProductCategoriesRepository : GenericRepository<ProductCategory>, IProductCategoriesDAL
    {
        private readonly B2B_Context _context;
        public efProductCategoriesRepository(B2B_Context context) : base(context)
        {
            _context = context;
        }

        public ProductCategory GetProductCategoryByID(int id)
        {
            var productCategory = _context.productCategories.Where(x=>x.ProductCategoryID == id).FirstOrDefault();
            return productCategory;
        }
    }
}
