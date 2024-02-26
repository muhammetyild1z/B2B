using B2B.DataAccessLayer.Abstract;
using B2B.DataAccessLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;

namespace B2B.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly B2B_Context _context;

        public GenericRepository(B2B_Context context)
        {
            _context = context;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            try
            {
                return _context.Set<T>().AsNoTracking().ToList();


            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public async Task<OperationResult> InsertAsync(T entity)
        {

            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return OperationResult.Success;

            }
            catch (Exception)
            {

                return OperationResult.Failure;
            }

        }

        public async Task<OperationResult> UpdateAsync(T entity, T unchanged)
        {
            try
            {
                _context.Entry(unchanged).CurrentValues.SetValues(entity);
                _context.SaveChanges();

                return OperationResult.Success;
            }
            catch (Exception)
            {

                return OperationResult.Failure;
            }
        }
    }
}
