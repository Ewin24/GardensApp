using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
<<<<<<< HEAD
public  class City :BaseEntity
{
  

    public string? Name { get; set; }

    public int? IdStateFk { get; set; }

    public virtual State? IdStateFkNavigation { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
=======
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
public partial class City : BaseEntity
{
    public string Name { get; set; }

    public int IdStateFk { get; set; }

    public virtual State IdStateFkNavigation { get; set; }

    public virtual ICollection<LocationClient> LocationClients { get; set; } = new List<LocationClient>();

    public virtual ICollection<LocationOffice> LocationOffices { get; set; } = new List<LocationOffice>();
<<<<<<< HEAD
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
}
