using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOrder : IGeneric<Order>
    {
        Task<IEnumerable<object>> GetAllStatus();
        Task<IEnumerable<Order>> GetAllDeliveredEarlier();
        Task<IEnumerable<Order>> GetOrderByStatusYear(string status, int year);
    }
}
