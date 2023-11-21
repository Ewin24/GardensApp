using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

    public class BossRepository : GenericRepository<Boss>, IBoss
    {
        private readonly  JardineriaContext _context;
        public BossRepository(JardineriaContext context) : base(context)
        {
            _context = context;   
        }
    }
