using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces
{
    public interface IProduct : IGenericString<Product>
    {
        Task<IEnumerable<Product>> GetByGamaStock(string productLine, int stockQuantity);
        Task<IEnumerable<Product>> GetNeverInOrder();
        Task<IEnumerable<object>> GetNeverInOrderspecified();
        Task<Product> GetByHigherSalesPrice();
        Task<IEnumerable<Product>> GetByNotInOrder();
    }
}