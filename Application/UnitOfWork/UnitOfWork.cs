using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GardenApiContext _context;

        public ICity _cities;

        public ICountry _countries;

        public IState _states;

        public IBoss _bosses;

        public IClient _clients;

        public ICompany _companys;

        public IContact _contacts;

        public IEmployee _employees;

        public ILocation _locations;

        public IOffice _offices;

        public IOrder _orders;

        public IOrderDetail _orderDetails;

        public IPayment _payments;

        public IProduct _products;

        public IProductLine _productLines;

        public IProveedor _proveedors;

        public ITypeContact _typeContacts;



        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public UnitOfWork(GardenApiContext context)
        {
            _context = context;
        }

        public ICity Cities
        {
            get
            {
                _cities ??= new CityRepository(_context);
                return _cities;
            }
        }
        public ICountry Countries
        {
            get
            {
                _countries ??= new CountryRepository(_context);
                return _countries;
            }
        }
        public IClient Clients
        {
            get
            {
                _clients ??= new ClienteRepository(_context);
                return _clients;
            }
        }

        public IBoss Bosses
        {
            get
            {
                _bosses ??= new BossRepository(_context);
                return _bosses;
            }
        }
        public ICompany Companys
        {
            get
            {
                _companys ??= new CompanyRepository(_context);
                return _companys;
            }
        }

        public IContact Contacts
        {
            get
            {
                _contacts ??= new ContactRepository(_context);
                return _contacts;
            }
        }
        public IEmployee Employees
        {
            get
            {
                _employees ??= new EmployeeRepository(_context);
                return _employees;
            }
        }
        public ILocation Locations
        {
            get
            {
                _locations ??= new LocationRepository(_context);
                return _locations;
            }
        }

        public IOffice Offices
        {
            get
            {
                _offices ??= new OfficeRepository(_context);
                return _offices;
            }
        }

        public IOrderDetail OrderDetails
        {
            get
            {
                _orderDetails ??= new OrderDetailRepository(_context);
                return _orderDetails;
            }
        }
        public IOrder Orders
        {
            get
            {
                _orders ??= new OrderRepository(_context);
                return _orders;
            }
        }

        public IPayment Payments
        {
            get
            {
                _payments ??= new PaymentRepository(_context);
                return _payments;
            }
        }
        public IProductLine ProductLines
        {
            get
            {
                _productLines ??= new ProductLineRepository(_context);
                return _productLines;
            }
        }

        public IProduct Products
        {
            get
            {
                _products ??= new ProductRepository(_context);
                return _products;
            }
        }
        public IProveedor Proveedors
        {
            get
            {
                _proveedors ??= new ProveedorRepository(_context);
                return _proveedors;
            }
        }

        public IState States
        {
            get
            {
                _states ??= new StateRepository(_context);
                return _states;
            }
        }  

        public ITypeContact TypeContacts
        {
            get
            {
                _typeContacts ??= new TypeContacRepository(_context);
                return _typeContacts;
            }
        }
    }
}