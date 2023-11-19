using System;
using System.Collections.Generic;

namespace Domain.Entities;

<<<<<<< HEAD
public class Boss:BaseEntity
=======
public partial class Boss : BaseEntity
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
{
    public string Name { get; set; } = null!;

    public int? DentificationArd { get; set; }

    public int? Cellphone { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
