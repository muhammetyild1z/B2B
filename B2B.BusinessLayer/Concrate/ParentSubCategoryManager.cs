using B2B.BusinessLayer.Abstract;
using B2B.DataAccessLayer.Abstract;
using B2B.EntityLayer.Concrate;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.Concrate
{
    public class ParentSubCategoryManager : IParentSubCategoryService
    {
        IParentSubCategoryDAL _parentCategory;

        public ParentSubCategoryManager(IParentSubCategoryDAL parentCategory)
        {
            _parentCategory = parentCategory;
        }

        public void TDelete(ParentSubCategory entity)
        {
            _parentCategory.Delete(entity);
        }

        public ParentSubCategory TGetByID(int id)
        {
            return _parentCategory.GetByID(id);
        }

        public List<ParentSubCategory> TGetList()
        {
            return _parentCategory.GetList();
        }

        public ParentSubCategory TGetParentSubByID(int id)
        {
            return _parentCategory.GetParentSubByID( id);
        }

        public async Task<OperationResult> TInsertAsync(ParentSubCategory entity)
        {
            return await _parentCategory.InsertAsync(entity);
         
        }

        public async Task<OperationResult> TUpdateAsync(ParentSubCategory entity, ParentSubCategory unchanged)
        {
            return await _parentCategory.UpdateAsync(entity, unchanged);
         
        }
    }
}
