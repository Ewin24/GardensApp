using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
<<<<<<< HEAD
public class State :BaseEntity 
{


    public string? Name { get; set; }

    public int? IdCountryFk { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country? IdCountryFkNavigation { get; set; }
=======
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
public partial class State : BaseEntity
{
    public string Name { get; set; }

    public int IdCountryFk { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country IdCountryFkNavigation { get; set; }
<<<<<<< HEAD
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
}
