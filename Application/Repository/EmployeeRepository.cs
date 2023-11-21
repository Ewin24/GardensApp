using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class EmployeeRepository : GenericRepository<Employee>, IEmployee
{
    private readonly JardineriaContext _context;
    public EmployeeRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }
    //6. Devuelve un listado que muestre el nombre de cada empleado, el nombre de su jefe y el nombre del jefe de su jefe.
    public async Task<IEnumerable<object>> GetNameAndBossChief()
    {
        return await _context.Employees
                             .Select(c => new
                             {
                                 c.FirstName,
                                 Boss = c.IdBossFkNavigation.Name,
                                 Chief = c.IdBossFk

                             })
                             .ToListAsync();
    }

      //9. Devuelve un listado con los datos de los empleados que no tienen clientes asociados y el nombre de su jefe asociado.
   /*   public async Task<IEnumerable<Employee>> GetNotAssociatedcustomerBossName()
     {
         
         return await _context.Employees
                             .Include(e => e.BossId)
                             .Where(e => !e.Orders.Any())
                             .ToListAsync();
     } */
    //3. Devuelve un listado que muestre solamente los empleados que no tienen un cliente asociado junto con los datos de la oficina donde trabajan

    // public async Task<IEnumerable<Employee>> GetNotAssociatedEmployeeOffice()
    // {
    //     //conex
    //     return await _context.Employees
    //                          .Include(e => e.OfficeCode)
    //                          .ThenInclude(o => o.Address)
    //                          .Where(e => !e.Orders.Any()).ToListAsync();
    // }

    //            //4. Devuelve un listado que muestre los empleados que no tienen una oficina asociada y los que no tienen un cliente asociado.
    //     public async Task<IEnumerable<Employee>> GetNotAssociatedEmployeeAndOffice()
    //     {
    //         //conex
    //         return await _context.Employees
    //                             .Include(e => e.OfficeCode)
    //                             .ThenInclude(o => o.Address)
    //                             .Where(e => e.OfficeId == null || !e.Orders.Any()).ToListAsync();
    //     }

    //1. ¿Cuántos empleados hay en la compañía?
    public async Task<object> GetEmployeesQuantity()
    {
        return new { EmployeesQuantity = await _context.Employees.CountAsync() };
    }

    //7. Devuelve el nombre de los representantes de ventas y el número de clientes
    // public async Task<IEnumerable<object>> GetEmployeesCustomerQuantity()
    // {
    //     return await _context.Employees
    //                         .Where(e => e.Position == "REPRESENTANTE VENTAS")
    //                         .GroupBy(e => e.Orders.FirstOrDefault().CustomerId)
    //                         .Select(g => new{
    //                             g.FirstOrDefault().Name,
    //                             customersAsociated = g.Count()
    //                         }).ToListAsync();
    // }
    //14. Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos empleados que no sean representante de ventas de ningún cliente.
    // public async Task<IEnumerable<object>> GetEmployeesWithoutOrder()
    // {
    //     return await _context.Employees
    //                         .Where(e => e.JobTitle == "REPRESENTANTE VENTAS"
    //                         && !e.Orders.Any())
    //                         .Select(e => new{
    //                             e.Name,
    //                             LastName = e.LastName1 + " " + e.LastName2,
    //                             e.JobTitle,
    //                             e.Office.Phone
    //                         }).ToListAsync();
    // }
   

    //5. Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos empleados que no sean representante de ventas de ningún cliente
    // public async Task<IEnumerable<object>> GetDataByJobTitle()
    // {
    //     return await _context.Employees
    //                         .Where(e => !e.Orders.Any())
    //                         .Where(e => e.JobTitle == "REPRESENTANTE VENTAS"
    //                         && !e.Orders.Any())
    //                         .Select(e => new{
    //                             e.Name,
    //                             LastName = e.LastName1 + " " + e.LastName2,
    //                             e.JobTitle,
    //                             e.Office.Phone
    //                         }).ToListAsync();
    // }
}