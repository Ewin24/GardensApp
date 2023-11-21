using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class OrderRepository : GenericRepository<Order>, IOrder
{
    private readonly JardineriaContext _context;

    public OrderRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }
    //10. Devuelve un listado con el código de pedido, código de cliente, fecha
    //esperada y fecha de entrega de los pedidos cuya fecha de entrega ha sido al
    //menos dos días antes de la fecha esperada.

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
    public async Task<IEnumerable<Order>> GetAllDeliveredEarlier()
    {
        //true
        return await _context.Orders
                .Where(o => (o.DeliveryDate.HasValue ? o.DeliveryDate.Value.Day + 2 : DateTime.MinValue.Day) <= o.ExpectedDate.Day &&
                o.DeliveryDate.HasValue)
                .ToListAsync();
    }
    //11. Devuelve un listado de todos los pedidos que fueron X en X.
    public async Task<IEnumerable<Order>> GetOrderByStatusYear(string status, int year)
    {//true
        return await _context.Orders
                .Where(o => o.Status.ToUpper() == status.ToUpper() && o.OrderDate.Year == year)
                .ToListAsync();
    }
    /* //     //12. Devuelve un listado de todos los pedidos que han sido (status X) en el mes  X de cualquier año.
     public async Task<IEnumerable<Order>> GetAllByMonth(string status, string Month)
     {
         
         List<Order> OrdersByMonth = new();
         if(DateOnly.TryParseExact(Month,"MMMM", OrderDetail. DateTimeStyles.None, out  DateOnly targetDate))
         {
             OrdersByMonth = await _context.Orders
                 .Where(o => o.Status.ToUpper() == status.ToUpper() && targetDate.Month == o.OrderDate.Month)
                 .ToListAsync();
         }
         return OrdersByMonth;

     } */

    //4. ¿Cuántos pedidos hay en cada estado? Ordena el resultado de forma descendente por el número de pedidos.
    public async Task<object> GetOrdersQuantityByStatus()
    {
        var result = await _context.Orders
            .GroupBy(o => o.Status)
            .Select(g => new { Status = g.Key, orderQuantity = g.Count() }).OrderByDescending(o => o.orderQuantity)
            .ToListAsync();

        return result;
    }

    public async Task<object> GetByDifferentProdQuantity()
    {
        return new { DiffProductQuantity = await _context.Orders.Select(o => o.OrderDetails.Select(od => od.ProductCode).Distinct()).CountAsync() };
    }
    //16. Muestre la suma total de todos los pagos que se realizaron para cada uno de los años que aparecen en la tabla pagos.

     /* public async Task<IEnumerable<object>> GetOrderTotalSumByYear()
     {
         return await _context.Orders
                             .Where(o => o.PaymentId != null)
                             .GroupBy(o => o.Payment.PaymentDate)
                             .Select(g => new
                             {
                                 PaymentDate = g.Key,
                                 Total = g.Sum(o => o.Payment != null ? o.Payment.Total : 0)
                             })
                             .OrderByDescending(n => n.Total)
                             .ToListAsync();
     } */

}
