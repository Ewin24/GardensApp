using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
<<<<<<< HEAD
public  class Proveedor :BaseEntity
{
   

    public string Name { get; set; } = null!;

    public int? DentificationArd { get; set; }

    public int? Cellphone { get; set; }
=======
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068
public partial class Proveedor : BaseEntity
{

    public string Name { get; set; } = null!;

    public int DentificationArd { get; set; }

    public int Cellphone { get; set; }
<<<<<<< HEAD
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
=======
>>>>>>> ce41551957fea3c94be6e3bf99403f9e4982f068

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
