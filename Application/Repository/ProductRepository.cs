using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class ProductRepository : GenericRepositoryString<Product>, IProduct
{
     private readonly JardineriaContext _context;
    public ProductRepository(JardineriaContext context) : base(context)
    {
        _context = context;
    }
                       //15. Devuelve un listado con todos los productos que pertenecen a la gama Ornamentales y que tienen más de 100 unidades en stock. El listado deberá estar ordenado por su precio de venta, mostrando en primer lugar los de mayor precio.

        // public async Task<IEnumerable<Product>> GetByGamaStock(string ProductLine, int StockQuantity)
        // {//fix
        //     return await _context.Products
        //                         .Where(p => p.ProductLineNavigation ==  && p.StockQuantity >  StockQuantity)
        //                         .OrderByDescending(p => p.SellingPrice)
        //                         .ToListAsync();
        // }

                        //8. Devuelve un listado de las diferentes gamas de producto que ha comprado cada cliente. 1.4.6 Consultas multitabla (Composición externa) Resuelva todas las consultas utilizando las cláusulas LEFT JOIN, RIGHT JOIN, NATURAL LEFT JOIN y NATURAL RIGHT JOIN.
        public async Task<IEnumerable<object>> GetByProductGama()
        {
            //fix
            return await _context.Products
                                .Include(p => p.ProductLine)
                                .Select(p => new{ProductGama = p.ProductLineNavigation.Products})
                                .Distinct()
                                .ToListAsync();
        }
                      //5. Devuelve un listado de los productos que nunca han aparecido en un pedido.
        public async Task<IEnumerable<Product>> GetNeverInOrder()
        {
            return await _context.Products
                                .Where(p => !p.OrderDetails.Any())
                                .ToListAsync();
        }

                       //6. Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripción y la imagen del producto.
        public async Task<IEnumerable<object>> GetNeverInOrderspecified()
        {
            return await _context.Products
                                .Where(p => !p.OrderDetails.Any())
                                .Select(p => new{
                                    p.Name,
                                    p.Description,
                                    p.Dimensions
                                }).ToListAsync();
        }
                   //10. Calcula el número de productos diferentes que hay en cada uno de los pedidos.
    
    public async Task<object> GetByDifferentProdQuantity()
    {
        return new{ DiffProductQuantity = await _context.Orders.Select(o => o.OrderDetails.Select(od => od.ProductCode).Distinct()).CountAsync()};
    }
    
                //2. Devuelve el nombre del producto que tenga el precio de venta más caro.
        public async Task<Product> GetByHigherSalesPrice()
        {
            return await _context.Products
                                .OrderByDescending(p => p.SellingPrice)
                                .FirstOrDefaultAsync();
        }
               //13. Devuelve un listado de los productos que nunca han aparecido en un pedido.
        public async Task<IEnumerable<Product>> GetByNotInOrder()
        {
            return await _context.Products
                                .Where(p => !p.OrderDetails.Any())
                                .ToListAsync();
        }


}
