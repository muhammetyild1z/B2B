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
    public class efParentSubCategoryRepository : GenericRepository<ParentSubCategory>, IParentSubCategoryDAL
    {
       private readonly B2B_Context _context;

        public efParentSubCategoryRepository(B2B_Context context) : base(context)
        {
            _context = context;
        }

        public ParentSubCategory GetParentSubByID(int id)
        {
            var parentSubCategory = _context.parentSubCategories.Where(x=>x.ParentSubCategoryID == id).FirstOrDefault();
            return parentSubCategory;
        }
    }
}
