using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICity Cities { get; }
        ICountry Countries { get; }
        IState States { get; }
        IBoss Bosses { get; }
        IClient Clients { get; }
        ICompany Companys { get; }
        IContact Contacts { get; }
        IEmployee Employees{ get; }
        ILocation Locations{ get; }
        IOffice Offices { get; }
        IOrder Orders{ get; }
        IOrderDetail OrderDetails{ get; }
        IPayment Payments { get; }
        IProduct Products{ get; }
        IProductLine ProductLines{ get; }
        IProveedor Proveedors{ get; }
        ITypeContact TypeContacts { get; }
        Task<int> SaveAsync();
    }
}
