using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = null!;
        public decimal CreditLimit { get; set; }

        // public int IdEmployeeFk { get; set; }

        // public int IdContactFk { get; set; }

        // public virtual Contact IdContactFkNavigation { get; set; }

        // public virtual Employee IdEmployeeFkNavigation { get; set; }

        // public virtual ICollection<LocationClient> LocationClients { get; set; } = new List<LocationClient>();

        // public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        // public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}