using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
using Domain.Entities;

namespace Domain.Interfaces;

    public interface IUnitOfWork{
        IBoss Bosses { get; }
        ICity Cities {get;}
        IContact Contacts {get;}
        ICountry Countries {get;}
        IEmployee Employee {get;}
        ILocationClient LocationClients {get;}
        ILocationOffice LocationOffices {get;}
        IOffice Offices {get;}
        IOrder Orders {get;}
        IOrderDetail OrderDetails {get;}
        IPayment Payment {get;}
        IProduct Products {get;}
        IProductLine ProductLines {get;}
        IProveedor Proveedores {get;}
        IState States {get;}
        
        Task<int> SaveAsync();
    }
<<<<<<< HEAD
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)

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
=======

>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
