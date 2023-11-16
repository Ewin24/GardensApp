using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateOnly CreationDate { get; set; }

    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();
}
