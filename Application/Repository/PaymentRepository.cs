using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class PaymentRepository : GenericRepositoryString<Payment>, IPayment
{
    private readonly JardineriaContext _context;
    public PaymentRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }

    //13. Devuelve un listado con todos los pagos que se realizaron en el año X mediante X. Ordene el resultado de mayor a menor.
    public async Task<IEnumerable<Payment>> GetByPaymentMethodYear()
    {

        return await _context.Payments
                            .Include(p => p.PaymentMethod)
                            .Where(p => p.PaymentMethod.ToUpper() == "CreditCard" && p.PaymentDate.Year.Equals("2006"))
                            .OrderByDescending(p => p.Total)
                            .ToListAsync();
    }

    //14. Devuelve un listado con todas las formas de pago que aparecen en la tabla pago.
    public async Task<IEnumerable<object>> GetPayMethods()
    {
        return await (_context.Payments
            .Select(p => p.PaymentMethod)
            .Distinct())
            .ToListAsync();
    }

    // 3. ¿Cuál fue el pago medio en 2009?
    public async Task<object> GetOrderPaymentAverangeIn2009()
    {
        return new { PaymentAverange = await _context.Payments.Where(p => p.PaymentDate.Year.Equals("2009")).AverageAsync(p => p.Total) };
    }

     // #3 codigo 2008
    /*  public async Task<IEnumerable<Client>> GetIdByPaymentDateE(int year)
     {
         return await _context.Clients
                             .Where(c => c.Orders.Any(o => o.Payment.PaymentDate.Year == year))
                             .Distinct()
                             .ToListAsync();
     } */
}
