using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class LocationRepository : GenericRepository<Location>, ILocation
    {
        public LocationRepository(GardenApiContext context) : base(context)
        {
        }
    }
}