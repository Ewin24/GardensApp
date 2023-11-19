using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class CompanyRepository : GenericRepository<Company>, ICompany
    {
        private readonly GardenApiContext _context;
        public CompanyRepository(GardenApiContext context) : base(context)
        {
            context = _context;
        }
    }
}