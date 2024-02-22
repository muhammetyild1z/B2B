using B2B.DataAccessLayer.Abstract;
using B2B.DataAccessLayer.Concrate;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<T>> GetListAsync()
        {
            try
            {
                var entities = await _context.Set<T>().ToListAsync();
                return entities;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task InsertAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
               await _context.SaveChangesAsync();
               
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task UpdateAsync(T entity, T unchanged)
        {
            try
            {
                _context.Entry(unchanged).CurrentValues.SetValues(entity);
              await  _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
