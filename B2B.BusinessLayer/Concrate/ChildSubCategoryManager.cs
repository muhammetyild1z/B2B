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
    public class ChildSubCategoryManager : IChildSubCategoryService
    {
        IChildSubCategoryDAL _childCategory;

        public ChildSubCategoryManager(IChildSubCategoryDAL childCategory)
        {
            _childCategory = childCategory;
        }

        public void TDelete(ChildSubCategory entity)
        {
            _childCategory.Delete(entity);
        }

        public ChildSubCategory TGetByID(int id)
        {
           return _childCategory.GetByID(id);   
        }

        public ChildSubCategory TGetChildSubByID(int id)
        {
            return _childCategory.GetChildSubByID(id);
        }

        public List<ChildSubCategory> TGetList()
        {
            return _childCategory.GetList();
        }

        public async Task<OperationResult> TInsertAsync(ChildSubCategory entity)
        {
        return  await _childCategory.InsertAsync(entity);
           // return OperationResult.Success;
        }

        public async Task<OperationResult> TUpdateAsync(ChildSubCategory entity, ChildSubCategory unchanged)
        {
            return await _childCategory.UpdateAsync(entity, unchanged);
           // return OperationResult.Success;
        }
    }
}
