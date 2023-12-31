using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPayment : IGenericString<Payment>
    {
        Task<object> GetOrderPaymentAverangeIn2009();
        Task<IEnumerable<Payment>> GetByPaymentMethodYear();
        Task<IEnumerable<object>> GetPayMethods();
    }
}