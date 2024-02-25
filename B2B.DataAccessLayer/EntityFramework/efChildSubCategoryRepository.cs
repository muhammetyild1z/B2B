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
    public class efChildSubCategoryRepository : GenericRepository<ChildSubCategory>, IChildSubCategoryDAL
    {
        private readonly B2B_Context _context;
        public efChildSubCategoryRepository(B2B_Context context) : base(context)
        {
            _context = context;
        }

        public ChildSubCategory GetChildSubByID(int id)
        {
           var childSubCategory = _context.childSubCategories.Where(x=>x.ChildSubCategoryID == id).FirstOrDefault();
            return childSubCategory;
        }
    }
}
