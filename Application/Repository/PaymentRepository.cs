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

    //14. Devuelve un listado con todas las formas de pago que aparecen en la tabla pago. Tenga en cuenta que no deben aparecer formas de pago repetidas.
    //Por mi parte normalice los metodos de pago, así que solamente es necesario utilizar el metodo generico GetAllAsync.
    // public override async Task<(int totalRegistros, IEnumerable<Payment> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    // {
    //     //se debe arreglar el metodo GetAllAsync 
    //     var query = _context.Payments as IQueryable<Payment>;

    //     if (!string.IsNullOrEmpty(search))
    //     {
    //         query = query.Where(p => p.Id.ToString() == search);
    //     }

    //     query = query.OrderBy(p => p.Id);
    //     var totalRegistros = await query.CountAsync();
    //     var registros = await query
    //         .Skip((pageIndex - 1) * pageSize)
    //         .Take(pageSize)
    //         .ToListAsync();

    //     return (totalRegistros, registros);
    // }

    // 3. ¿Cuál fue el pago medio en 2009?
    public async Task<object> GetOrderPaymentAverangeIn2009()
    {
        return new { PaymentAverange = await _context.Payments.Where(p => p.PaymentDate.Year.Equals("2009")).AverageAsync(p => p.Total) };
    }
}
