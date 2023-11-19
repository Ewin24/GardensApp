using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class ContactRepository : GenericRepository<Contact>, IContact
    {
        private readonly GardenApiContext _context;
        public ContactRepository(GardenApiContext context) : base(context)
        {
            context = _context;
        }
    }
}