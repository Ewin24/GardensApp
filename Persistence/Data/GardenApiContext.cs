using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public partial class GardenApiContext : DbContext
{

    public  DbSet<Boss> Bosses { get; set; }

    public  DbSet<City> Cities { get; set; }

    public  DbSet<Client> Clients { get; set; }

    public  DbSet<Company> Companies { get; set; }

    public  DbSet<Contact> Contacts { get; set; }

    public  DbSet<Country> Countries { get; set; }

    public  DbSet<Employee> Employees { get; set; }

    public  DbSet<Location> Locations { get; set; }

    public  DbSet<Office> Offices { get; set; }

    public  DbSet<Order> Orders { get; set; }

    public  DbSet<OrderDetail> OrderDetails { get; set; }

    public  DbSet<Payment> Payments { get; set; }

    public  DbSet<Product> Products { get; set; }

    public  DbSet<ProductLine> ProductLines { get; set; }

    public  DbSet<Proveedor> Proveedors { get; set; }

    public  DbSet<State> States { get; set; }

    public  DbSet<TypeContact> TypeContacts { get; set; }

    public GardenApiContext(DbContextOptions<GardenApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    } 
   
}
