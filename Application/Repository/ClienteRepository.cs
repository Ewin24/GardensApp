using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class ClienteRepository : GenericRepository<Client>, IClient
    {
        public ClienteRepository(GardenApiContext context) : base(context)
        {
        }
    }
}