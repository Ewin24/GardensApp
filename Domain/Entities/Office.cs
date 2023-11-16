using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Office
{
    public string OfficeCode { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int? IdCountryFk { get; set; }

    public virtual ICollection<Employed> Employeds { get; set; } = new List<Employed>();

    public virtual Country? IdCountryFkNavigation { get; set; }
}
