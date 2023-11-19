using System;
using System.Collections.Generic;

namespace Domain.Entities;

public  class Company :BaseEntity
{

    public string Name { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateOnly CreationDate { get; set; }
}
