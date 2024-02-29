using B2B.BusinessLayer.Abstract;
using B2B.DataAccessLayer.Abstract;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.BusinessLayer.Concrate
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TDelete(EntityLayer.Concrate.Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public EntityLayer.Concrate.Contact TGetByID(int id)
        {
           return _contactDal.GetByID(id);
        }

        public List<EntityLayer.Concrate.Contact> TGetList()
        {
            return _contactDal.GetList();
        }

        public async Task<OperationResult> TInsertAsync(EntityLayer.Concrate.Contact entity)
        {
            try
            {
                return await _contactDal.InsertAsync(entity);   
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OperationResult> TUpdateAsync(EntityLayer.Concrate.Contact entity, EntityLayer.Concrate.Contact unchanged)
        {
            try
            {
                return await _contactDal.UpdateAsync(entity, unchanged);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
