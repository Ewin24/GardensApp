using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class ProductLineRepository : GenericRepository<ProductLine>, IProductLine
    {
        public ProductLineRepository(GardenApiContext context) : base(context)
        {
        }
    }
}