using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProduct
    {
        private readonly GardenApiContext _context;
        public ProductRepository(GardenApiContext context) : base(context)
        {
            context = _context;
        }
    }
}