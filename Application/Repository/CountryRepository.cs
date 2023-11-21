using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class CountryRepository : GenericRepository<Country>, ICountry
{
    private readonly JardineriaContext _context;
    public CountryRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }
                        //2. ¿Cuántos clientes tiene cada país?
        // public async Task<IEnumerable<object>> GetCustomersQuantityByCountry()
        // {
        //     return await _context.Countries
        //                         .Select(c => new{
        //                             c.Name,
        //                             CustomersQuantity = 
        //                             c.States.SelectMany(s => s.Cities
        //                                     .SelectMany(c => c.Adress
        //                                     .Select(a => a.Customers.Count)
        //                                     )).Sum()
        //                         })
        //                         .ToListAsync();
         
        // }
}
