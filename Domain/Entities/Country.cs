using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
public  class Country :BaseEntity
{
    

    public string? Name { get; set; }
=======
public partial class Country : BaseEntity
{
    public string Name { get; set; }
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
