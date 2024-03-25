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
    public class UserFavoriManager : IUserFavoriService
    {
        IUserFavoriDAL _userFavori;

        public UserFavoriManager(IUserFavoriDAL userFavori)
        {
            _userFavori = userFavori;
        }

        public void TDelete(UserFavoriList entity)
        {
            _userFavori.Delete(entity);
        }

        public UserFavoriList TGetByID(int id)
        {
            return _userFavori.GetByID(id);
        }

        public List<UserFavoriList> TGetList()
        {
          return _userFavori.GetList();
        }

		public List<UserFavoriList> TGetListIncludeProductPrice()
		{
            return _userFavori.GetListIncludeProductPrice();
		}

		public async Task<OperationResult> TInsertAsync(UserFavoriList entity)
        {
            try
            {
                 await _userFavori.InsertAsync(entity);
                return OperationResult.Success;
            }
            catch (Exception)
            {

               return OperationResult.Failure;
            }
        }

        public async Task<OperationResult> TUpdateAsync(UserFavoriList entity, UserFavoriList unchanged)
        {
            try
            {
                await _userFavori.UpdateAsync(entity, unchanged);
                return OperationResult.Success;
            }
            catch (Exception)
            {

                return OperationResult.Failure;
            }
        }
    }
}
