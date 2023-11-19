using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
<<<<<<< HEAD
public  class Country :BaseEntity
{
    

    public string? Name { get; set; }
=======
public partial class Country : BaseEntity
{
    public string Name { get; set; }
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
public partial class Country : BaseEntity
{
    public string Name { get; set; }
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
