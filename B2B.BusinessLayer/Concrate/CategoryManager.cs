﻿using B2B.BusinessLayer.Abstract;
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
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDal;

        public CategoryManager(ICategoryDAL categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category TGetByID(int id)
        {
           return _categoryDal.GetByID(id);
        }

        public Task<List<Category>> TGetListAsync()
        {
           return _categoryDal.GetListAsync();
        }

        public async Task<OperationResult> TInsertAsync(Category entity)
        {
           await _categoryDal.InsertAsync(entity);
            return OperationResult.Success;
        }

        public async Task<OperationResult> TUpdateAsync(Category entity, Category unchanged)
        {
            await _categoryDal.UpdateAsync(entity, unchanged);
            return OperationResult.Success;
        }
    }
}
