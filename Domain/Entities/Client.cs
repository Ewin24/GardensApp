using System;
using System.Collections.Generic;
<<<<<<< HEAD

namespace Domain.Entities;

public  class Client :BaseEntity
{
  
    public int ClientCode { get; set; }

    public string ClientName { get; set; } = null!;

    public decimal? CreditLimit { get; set; }

    public int? IdEmployeeFk { get; set; }

    public int? IdContactFk { get; set; }

    public virtual Contact? IdContactFkNavigation { get; set; }

    public virtual Employee? IdEmployeeFkNavigation { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
=======
using Domain.Entities;

namespace Domain.Entities;

public partial class Client  : BaseEntity
{
    public string ClientName { get; set; } = null!;

    public decimal CreditLimit { get; set; }

    public int IdEmployeeFk { get; set; }

    public int IdContactFk { get; set; }

    public virtual Contact IdContactFkNavigation { get; set; }

    public virtual Employee IdEmployeeFkNavigation { get; set; }

    public virtual ICollection<LocationClient> LocationClients { get; set; } = new List<LocationClient>();
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
