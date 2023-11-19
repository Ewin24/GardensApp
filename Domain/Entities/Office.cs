using System;
using System.Collections.Generic;
<<<<<<< HEAD

namespace Domain.Entities;

public  class Office :BaseEntity
{
    public string OfficeCode { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
=======
using Domain.Entities;

namespace Domain.Entities;

public partial class Office : BaseEntityString
{

    public string Phone { get; set; } = null!;

    public int LocationOfficeFk { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual LocationOffice LocationOfficeFkNavigation { get; set; } = null!;
>>>>>>> 6d8ff27 (feat: :construction: New entities and configurations)
}
