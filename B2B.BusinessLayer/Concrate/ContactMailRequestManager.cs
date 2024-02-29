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
    public class ContactMailRequestManager : IContactMailRequestService
    {
        IContactMailRequestDal _contactMailRequest;

        public ContactMailRequestManager(IContactMailRequestDal contactMailRequest)
        {
            _contactMailRequest = contactMailRequest;
        }

        public void TDelete(ContactMailRequest entity)
        {
            _contactMailRequest.Delete(entity);
        }

        public ContactMailRequest TGetByID(int id)
        {
           return _contactMailRequest.GetByID(id);
        }

        public List<ContactMailRequest> TGetList()
        {
           return _contactMailRequest.GetList();
        }

        public async Task<OperationResult> TInsertAsync(ContactMailRequest entity)
        {
            try
            {

                return await _contactMailRequest.InsertAsync(entity);

            }
            catch (Exception ex)
            {

                return OperationResult.Failure;
            }
        }

        public async Task<OperationResult> TUpdateAsync(ContactMailRequest entity, ContactMailRequest unchanged)
        {
            try
            {

                return await _contactMailRequest.UpdateAsync(entity, unchanged);

            }
            catch (Exception ex)
            {

                return OperationResult.Failure;
            }
        }
    }
}
