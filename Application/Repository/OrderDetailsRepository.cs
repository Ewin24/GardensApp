using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetail
{
    private readonly JardineriaContext _context;
    public OrderDetailRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }
    //11. Calcula la suma de la cantidad total de todos los productos que aparecen en cada uno de los pedidos.
    public async Task<object> GetTotalSumProdInOrder()
    {
        return await _context.OrderDetails
                            .GroupBy(od => od.OrderCodeNavigation)

                            .Select(g => new
                            {
                                OrderId = g.Key,
                                TotalProductSum = g.Sum(p => Convert.ToInt32(p.Quantity))
                            }).ToListAsync();
    }

            //12. Devuelve un listado de los 20 productos más vendidos y el número total de unidades que se han vendido de cada uno. El listado deberá estar ordenado por el número total de unidades vendidas.
        // public async Task<IEnumerable<object>> GetMostSold()
        // {
        //     return await _context.OrderDetails
        //                     .GroupBy(od => od.ProductCode)
        //                     //conexion
        //                     .Select(g => new
        //                     { 
        //                         g.FirstOrDefault().Product.Name, 
        //                         g.FirstOrDefault().Product.GamaNavigation.Gama,
        //                         g.FirstOrDefault().Product.Supplier,
        //                         g.FirstOrDefault().Product.Description,
        //                         TotalProductSum = g.Sum(p => Convert.ToInt32(p.Cantidad))
        //                     })
        //                     .OrderByDescending(p => p.TotalProductSum)
        //                     .Take(20)
        //                     .ToListAsync();               

        // }

        
        //  public async Task<IEnumerable<object>> GetMostSoldGroupedByCod()
        // {
        //     return await _context.OrderDetails
        //                     .GroupBy(od => od.ProductCode)
                            
        //                     .Select(g => new
        //                     { 
        //                         g.FirstOrDefault().Product.Id,
        //                         g.FirstOrDefault().Product.Name, 
        //                         g.FirstOrDefault().Product.GamaNavigation.Gama,
        //                         g.FirstOrDefault().Product.Supplier,
        //                         g.FirstOrDefault().Product.Description,
        //                         TotalProductSum = g.Sum(p => Convert.ToInt32(p.Cantidad))
        //                     })
        //                     .OrderByDescending(p => p.Id)
        //                     .Take(20)
        //                     .ToListAsync();               
        // }

        
   //14. La misma información que en la pregunta anterior, pero agrupada por código de producto filtrada por los códigos que empiecen por OR. 
        // public async Task<IEnumerable<object>> GetMostSoldGroupedByCodFiltered(string letters)
        // {
        //     return await _context.OrderDetails
        //                     .Where(od => od.ProductCode.ToUpper().StartsWith(letters.ToUpper()))
        //                     .GroupBy(od => od.ProductCode)
                            
        //                     .Select(g => new
        //                     { 
        //                         g.FirstOrDefault().Product.Id,
        //                         g.FirstOrDefault().Product.Name, 
        //                         g.FirstOrDefault().Product.GamaNavigation.Gama,
        //                         g.FirstOrDefault().Product.Supplier,
        //                         g.FirstOrDefault().Product.Description,
        //                         TotalProductSum = g.Sum(p => Convert.ToInt32(p.Cantidad))
        //                     })
        //                     .OrderByDescending(p => p.Id)
        //                     .Take(20)
        //                     .ToListAsync();               
        // }
                //15. Lista las ventas totales de los productos que hayan facturado más de X euros. Se mostrará el nombre, unidades vendidas, total facturado y total facturado con impuestos (21% IVA).
        // public async Task<IEnumerable<object>> GetTotalSaleByQuantityRange(int range)
        // {
        //     return await _context.OrderDetails
        //                     .GroupBy(od => od.ProductCode)
        //                     .Select(g => new
        //                     { 
        //                         g.FirstOrDefault().Product.Name,
        //                         g.FirstOrDefault().UnitPrice,
        //                         Total = g.Sum(od => Math.Round(Convert.ToInt32(g.FirstOrDefault().Cantidad) * od.UnitPrice, 2)),
        //                         TotalWithTaxes = g.Sum(od => Math.Round(Convert.ToInt32(g.FirstOrDefault().Cantidad) * od.UnitPrice , 2)) * (decimal)1.21
        //                     })
        //                     .Where(g => g.Total > range)
        //                     .OrderByDescending(g => g.Total)
        //                     .ToListAsync();
        // }
        //       public async Task<object> GetByHigherUnitsPrice()
        // {
        //     return await _context.OrderDetails
        //                         .GroupBy( od => od.ProductCode)
        //                         .Select(g => new
        //                         {
        //                             g.FirstOrDefault().Product.Name,
        //                             TotalUnits = g.Sum(od => Convert.ToInt32(od.Cantidad))
        //                         })
        //                         .OrderByDescending(p => p.TotalUnits)
        //                         .FirstOrDefaultAsync();
        // }
}
