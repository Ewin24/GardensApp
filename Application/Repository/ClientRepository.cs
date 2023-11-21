using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;


public class ClientRepository : GenericRepository<Client>, IClient
{
    private readonly JardineriaContext _context;

    public ClientRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }
    //1. Devuelve un listado con el nombre de los todos los clientes españoles.
    // public async Task<IEnumerable<Client>> GetByCountry(string country)
    // {
    //     return await _context.Clients
    //         //ruta para el Nombre del pais
    //         .Where(c => c.LocationClients)
    //         .ToListAsync();
    // }
    //2. Devuelve un listado con los distintos estados por los que puede pasar un pedido.

    public async Task<IEnumerable<Object>> GetAllStatus()
    {
        //
        //true
        var dato = await (
            from o in _context.Orders
            select new
            {
                status = o.Status
            }
        ).Distinct()
        .ToListAsync();
        return dato;

    }

    //. Devuelve un listado con el código de cliente de aquellos clientes que
    // realizaron algún pago en 2008. Tenga en cuenta que deberá eliminar
    // aquellos códigos de cliente que aparezcan repetidos. Resuelva la consulta:
    // • Utilizando la función YEAR de MySQL.
    // • Utilizando la función DATE_FORMAT de MySQL. 
    // • Sin utilizar ninguna de las funciones anteriores.

    public async Task<IEnumerable<Client>> GetIdByPaymentDate(int year)
    {
        //True
        return await _context.Clients
                            .Where(c => c.Payments.Any(o => o.PaymentDate.Year == year))
                            .Distinct()
                            .ToListAsync();
    }
    // #3 codigo 2008
    // public async Task<IEnumerable<Client>> GetIdByPaymentDateE(int year)
    // {
    //     //bad
    //     return await _context.Clients
    //                         .Where(c => c.Orders.Any(o => o.Payment.PaymentDate.Year == year))
    //                         .Distinct()
    //                         .ToListAsync();
    // }
    //9. Devuelve un listado con el código de pedido, código de cliente, fecha esperada y fecha de entrega de los pedidos que no han sido entregados a tiempo.
    public async Task<IEnumerable<Order>> GetAllNotDeliveredOnTime()
    {
        return await _context.Orders
                .Where(o => o.ExpectedDate > o.DeliveryDate)
                .ToListAsync();
    }

    // 16. Devuelve un listado con todos los clientes que sean de la ciudad de Madrid y cuyo representante de ventas tenga el código de empleado 11 o 30. 1.4.5 Consultas multitabla (Composición interna) Resuelva todas las consultas utilizando la sintaxis de SQL1 y SQL2. Las consultas con sintaxis de SQL2 se deben resolver con INNER JOIN y NATURAL JOIN.

    // public async Task<IEnumerable<Client>> GetByCityEmployee(string city, int employeeId1, int employeeId2)
    // {
    //     return await _context.Clients
    //                         .Where(c => c.IdContactFkNavigation.City.Name.ToUpper() == city.ToUpper() && c.Orders.All(o => o.EmployeeId == employeeId1 || o.EmployeeId == employeeId2))
    //                         .ToListAsync();
    // }

    // public async Task<IEnumerable<object>> GetNameAndEmployee()
    // {
    //     return await _context.Clients
    //                         .Include(c => c.Orders)
    //                         .ThenInclude(o => o.Employee)
    //                         .Select(c => new
    //                         {
    //                             c.ClientName,
    //                             associatedEmployees =
    //                             c.Orders.Select(o => new
    //                             {
    //                                 o.Employee.Name,
    //                                 LastName = o.Employee.LastName1,
    //                                 o.Employee.LastName2
    //                             }).Distinct()
    //                         })
    //                         .ToListAsync();
    // }
    //2. Muestra el nombre de los clientes que hayan realizado pagos junto con el nombre de sus representantes de ventas.
    // public async Task<IEnumerable<object>> GetByOrderEmployee()
    // {
    //     return await _context.Clients
    //                          .Include(c => c.Orders)
    //                          .ThenInclude(o => o.Employee)
    //                          .Where(c => c.Orders.Any())
    //                          .Select(c => new
    //                          {
    //                              c.Name,
    //                              associatedEmployees =
    //                              c.Orders.Select(o => new
    //                              {
    //                                  o.Employee.Name,
    //                              }).Distinct()
    //                          })
    //                          .ToListAsync();
    // }

    //3. Muestra el nombre de los clientes que no hayan realizado pagos junto con el nombre de sus representantes de ventas.
    // public async Task<IEnumerable<object>> GetByOrderNotPaymentEmployee()
    // {
    //     return await _context.Clients
    //                          .Include(c => c.Orders)
    //                          .ThenInclude(o => o.Employee)
    //                          .Where(c => c.Orders.Any(o => o. == null))
    //                          .Select(c => new
    //                          {
    //                              c.Name,
    //                              associatedEmployees =
    //                              c.Orders.Select(o => new
    //                              {
    //                                  o.Employee.Name,
    //                              }).Distinct()
    //                          })
    //                          .ToListAsync();
    // }


    // // 4. Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
    // public async Task<IEnumerable<object>> GetByOrderPaymentEmployee()
    // {
    //     return await _context.Clients
    //                          .Include(c => c.Orders)
    //                          .ThenInclude(o => o.Employee)
    //                          .Where(c => c.Orders.Any(o => o.PaymentId != null))
    //                          .Select(c => new
    //                          {
    //                              c.Name,
    //                              associatedEmployees =
    //                              c.Orders.Select(o => new
    //                              {
    //                                  o.Employee.Name,
    //                                  City = o.Employee.Office.Address.City.Name
    //                              }).Distinct()
    //                          })
    //                          .ToListAsync();
    // }

    //5. Devuelve el nombre de los clientes que no hayan hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
    // public async Task<IEnumerable<object>> GetByOrderNotPaymentEmployeeCity()
    // {

    //     return await _context.Clients
    //                          .Include(c => c.Orders)
    //                          .ThenInclude(o => o.Employee)
    //                          .Where(c => c.Orders.Any(o => o.PaymentId == null))
    //                          .Select(c => new
    //                          {
    //                              c.Name,
    //                              associatedEmployees =
    //                              c.Orders.Select(o => new
    //                              {
    //                                  o.Employee.Name,
    //                                  City = o.Employee.Office.Address.City.Name
    //                              }).Distinct()
    //                          })
    //                          .ToListAsync();
    // }

    //7. Devuelve el nombre de los clientes a los que no se les ha entregado a tiempo un pedido.
    public async Task<IEnumerable<Client>> GetNameNoDeliveryOnTime()
    {
        return await _context.Clients
                             .Where(c => c.Orders.Any(o => o.DeliveryDate > o.ExpectedDate))
                             .ToListAsync();
    }

    //2. Devuelve un listado que muestre los clientes que no han realizado ningún pago y los que no han realizado ningún pedido.
    public async Task<IEnumerable<Client>> GetByNotPaidAndNotOrder()
    {
        return await _context.Clients
                             .Where(c => !c.Orders.Any())
                             .ToListAsync();

    }
    // //5. ¿Cuántos clientes existen con domicilio en la ciudad de Madrid?
    // public async Task<object> GetByCustomerQuantityInCity(string city)
    // {
    //     return new { customerQuantity = await _context.Clients.Where(c => c.Address.City.Name.ToUpper() == city.ToUpper()).CountAsync() };
    // }
    // //6. ¿Calcula cuántos clientes tiene cada una de las ciudades que empiezan por M?
    // public async Task<object> GetByCustomerQuantityInLetterCity(string letter)
    // {
    //     return new
    //     {
    //         customerQuantity = await _context.Clients
    //     .Where(c => c.Address.City.Name.ToUpper().StartsWith(letter.ToUpper())).CountAsync()
    //     };
    // }

    //8. Calcula el número de clientes que no tiene asignado representante de ventas.
    public async Task<object> GetByNotAssignedEmployee()
    {
        return new { CustomerQuantity = await _context.Clients.Where(c => !c.Orders.Any()).CountAsync() };
    }
    //9. Calcula la fecha del primer y último pago realizado por cada uno de los clientes. El listado deberá mostrar el nombre y los apellidos de cada cliente.
    // public async Task<IEnumerable<object>> GetFirstLastPaymentByCustomer()
    // {
    //     return await _context.Clients
    //                         .Where(c => c.Orders.Any(o => o.PaymentId != null))
    //                         .Select(c => new
    //                         {
    //                             firstPayment = c.Orders.Min(o => o.Payment.PaymentDate),
    //                             LastPayment = c.Orders.Max(o => o.Payment.PaymentDate),
    //                             c.Name,
    //                             lastName = c.ContactName + " " + c.ContactLastName
    //                         }).ToListAsync();
    // }
    public async Task<Client> GetByGreatestCreditLimit()
    {
        return await _context.Clients
                            .OrderByDescending(c => c.CreditLimit)
                            .FirstOrDefaultAsync();
    }
    //4. Los clientes cuyo límite de crédito sea mayor que los pagos que haya realizado. (Sin utilizar INNER JOIN).
    // public async Task<IEnumerable<Client>> GetByHigherCreditLimitThanPayment()
    // {
    //     return await _context.Clients
    //                         .Where(c => c.Orders.Any(o => o.PaymentId != null))
    //                         .Where(c => c.CreditLimit > c.Orders.Sum(o => o.Payment.Total))
    //                         .ToListAsync();
    // }

    //9. Devuelve el nombre del producto que tenga el precio de venta más caro.
    public async Task<Product> GetByHigherSalesPrice()
    {
        return await _context.Products
                            .OrderByDescending(p => p.SellingPrice)
                            .FirstOrDefaultAsync();
    }
                    //11. Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.
        // public async Task<IEnumerable<Client>> GetByNotOrder()
        
        // {
        //     return await _context.Clients 
        //                         .Where(c => c.Orders.Any(o => o.Payments == null))
        //                         .ToListAsync();
        // }
        //                 //12. Devuelve un listado que muestre solamente los clientes que sí han realizado
        // public async Task<IEnumerable<Client>> GetByOrderPaid()
        // {
        //     return await _context.Clients 
        //                         .Where(c => c.Orders.Any(o => o.Payment != null))
        //                         .ToListAsync();
        // }
          public async Task<IEnumerable<object>> GetNameAndOrdersQuantity()
        {
            return await _context.Clients
                                .Select(c => new
                                {
                                    c.ClientName,
                                    c.Orders.Count
                                }).ToListAsync();
        }
                        //3. Devuelve el nombre del cliente, el nombre y primer apellido de su representante de ventas y el número de teléfono de la oficina del representante de ventas, de aquellos clientes que no hayan realizado ningún pago.
        // public async Task<IEnumerable<object>> GetDataAndEmployee()
        // {
        //     return await _context.Clients
        //                         .Where(c => c.Orders.Any(o => o.PaymentId == null))
        //                         .Select(c => new
        //                         {
        //                             c.Name,
        //                             AssociatedEmployees = c.Orders.Select(o => new
        //                             {
        //                                 o.Employee.Name,
        //                                 o.Employee.LastName1,
        //                                 OfficeNumber = o.Employee.Office.Phone
        //                             })
        //                         }).ToListAsync();
        // }
                        //4. Devuelve el listado de clientes donde aparezca el nombre del cliente, el nombre y primer apellido de su representante de ventas y la ciudad donde está su oficina.
        // public async Task<IEnumerable<object>> GetDataAndEmployeeCity()
        // {
        //     return await _context.Clients
        //                         .Select(c => new
        //                         {
        //                             c.ClientName,
        //                             AssociatedEmployees = c.Orders.Select(o => new
        //                             {
        //                                 o.Employee.Name,
        //                                 o.Employee.LastName1,
        //                                 OfficeCity = o.Employee.Office.Address.City.Name
        //                             })
        //                         }).ToListAsync();
        // }
                                //2. Devuelve el nombre de los clientes que hayan hecho pedidos en 2008 ordenados alfabéticamente de menor a mayor.
        public async Task<IEnumerable<Client>> GetByOrderInYear(int year)
        {
            return await _context.Clients
                                .Where(c => c.Orders.All(o => o.OrderDate.Year > year))
                                .OrderBy(c => c.ClientName)
                                .ToListAsync();
        }



}
