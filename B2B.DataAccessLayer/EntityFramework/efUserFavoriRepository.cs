using B2B.DataAccessLayer.Abstract;
using B2B.DataAccessLayer.Concrate;
using B2B.DataAccessLayer.Repositories;
using B2B.EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.DataAccessLayer.EntityFramework
{
    public class efUserFavoriRepository : GenericRepository<UserFavoriList>, IUserFavoriDAL
    {
		private readonly B2B_Context _context;
        public efUserFavoriRepository(B2B_Context context) : base(context)
        {
			_context= context;

		}

		public List<UserFavoriList> GetListIncludeProductPrice()
		{
			return _context.userFavoriLists.Include(x=>x.price)
				.Include(x=>x.price.Product)
				.Include(x => x.price.dimensions)
				.Include(x => x.price.color)
				//.Include(x => x.price.stock)
				.ToList();
		}
	}
}
