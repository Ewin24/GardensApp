using System;
using System.Collections.Generic;

namespace Domain.Entities;

public  class City :BaseEntity
{
  

    public string? Name { get; set; }

    public int? IdStateFk { get; set; }

    public virtual State? IdStateFkNavigation { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
