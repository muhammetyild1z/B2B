﻿using B2B.DataAccessLayer.Abstract;
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
    public class efBasketRepository : GenericRepository<Basket>, IBasketDAL
    {
        private readonly B2B_Context _context;
        public efBasketRepository(B2B_Context context) : base(context)
        {
            _context = context;
        }

        public Basket GetBasketByID(int id)
        {
            var basket = _context.baskets.Where(x => x.BasketID == id).FirstOrDefault();
            return basket;

        }

        public List<Basket> GetIncludeAllUserBasket()
        {
            return _context.baskets.Include(x => x.productPrice)
                .Include(x=>x.productPrice.Product)
                .Include(x=>x.productPrice.color)
                .Include(x=>x.productPrice.dimensions)
                .ToList();
        }
    }
}
