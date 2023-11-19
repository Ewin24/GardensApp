using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
public class State :BaseEntity 
{


    public string? Name { get; set; }

    public int? IdCountryFk { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country? IdCountryFkNavigation { get; set; }
=======
public partial class State : BaseEntity
{
    public string Name { get; set; }

    public int IdCountryFk { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country IdCountryFkNavigation { get; set; }
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
}
