using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contact
{
    public int Id { get; set; }

    public string ContactName { get; set; } = null!;

    public string ContactLastName { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
