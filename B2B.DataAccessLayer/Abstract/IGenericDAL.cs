using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task<OperationResult> InsertAsync(T entity);
        Task<OperationResult> UpdateAsync(T entity, T unchanged);
        void Delete(T entity);
        T GetByID(int id);
        List<T> GetList();

    }
}
