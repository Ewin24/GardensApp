using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Client
{
    public int ClientCode { get; set; }

    public string ClientName { get; set; } = null!;

    public decimal? CreditLimit { get; set; }

    public int? IdEmployedFk { get; set; }

    public int? IdCountryFk { get; set; }

    public int? IdContactFk { get; set; }

    public virtual Contact? IdContactFkNavigation { get; set; }

    public virtual Country? IdCountryFkNavigation { get; set; }

    public virtual Employed? IdEmployedFkNavigation { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
