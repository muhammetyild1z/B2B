using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.Abstract
{
    public interface IGenericService< T> where T : class
    {
        Task<OperationResult> TInsertAsync(T entity);
        Task<OperationResult> TUpdateAsync(T entity, T unchanged);
        void TDelete(T entity);
        T TGetByID(int id);
        List<T> TGetList();
    }
}
