using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Country
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Office> Offices { get; set; } = new List<Office>();

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
