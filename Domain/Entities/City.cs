using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
public  class City :BaseEntity
{
  

    public string? Name { get; set; }

    public int? IdStateFk { get; set; }

    public virtual State? IdStateFkNavigation { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
=======
public partial class City : BaseEntity
{
    public string Name { get; set; }

    public int IdStateFk { get; set; }

    public virtual State IdStateFkNavigation { get; set; }

    public virtual ICollection<LocationClient> LocationClients { get; set; } = new List<LocationClient>();

    public virtual ICollection<LocationOffice> LocationOffices { get; set; } = new List<LocationOffice>();
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
}
