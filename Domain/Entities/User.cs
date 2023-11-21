using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}