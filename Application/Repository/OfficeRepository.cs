using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class OfficeRepository : GenericRepository<Office>, IOffice
    {
        private readonly GardenApiContext _context;
        public OfficeRepository(GardenApiContext context) : base(context)
        {
            context = _context;
        }
    }
}