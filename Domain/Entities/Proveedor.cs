using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
public  class Proveedor :BaseEntity
{
   

    public string Name { get; set; } = null!;

    public int? DentificationArd { get; set; }

    public int? Cellphone { get; set; }
=======
public partial class Proveedor : BaseEntity
{

    public string Name { get; set; } = null!;

    public int DentificationArd { get; set; }

    public int Cellphone { get; set; }
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
