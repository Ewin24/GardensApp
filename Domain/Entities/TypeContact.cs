using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class TypeContact :BaseEntity
{

    public string? TypeContact1 { get; set; }

    public int? IdContactFk { get; set; }

    public virtual Contact? IdContactFkNavigation { get; set; }
}
