using System;
using System.Collections.Generic;

namespace Domain.Entities;

public  class Office :BaseEntity
{
    public string OfficeCode { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
