using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class OfficeRepository : GenericRepositoryString<Office>, IOffice
{
    private readonly JardineriaContext _context;
    public OfficeRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }
    // 7. Devuelve las oficinas donde no trabajan ninguno de los empleados que hayan sido los representantes de ventas de algún cliente que haya realizado la compra de algún producto de la gama Frutales.
    // public async Task<IEnumerable<Office>> GetByEmployeeWithProductGama(string gama)
    // {
    //     return await _context.Offices
    //                     .Include(o => o.LocationOfficeFk)
    //                     .ThenInclude(a => a.city)
    //                     .Where(o => o.Employees
    //                     .Any(e => e.JobTitle.ToUpper() == "REPRESENTANTE VENTAS") &&
    //                     !o.Employees.Any(e => e.Orders.Any(o => o.OrderDetails
    //                     .Any(od => od.Product.GamaNavigation.Gama.Equals(gama))))).ToListAsync();
    // }
    //9. Devuelve un listado con los datos de los empleados que no tienen clientes asociados y el nombre de su jefe asociado.
    // public async Task<IEnumerable<Employee>> GetNotAssociatedcustomerBossName()
    // {
    //     //empleado - jefe
    //     return await _context.Employees
    //                         .Include(e => e.Boss)
    //                         .Where(e => !e.Orders.Any())
    //                         .ToListAsync();
    // }

}