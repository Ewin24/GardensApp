using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class ContactDto
    {
        public int Id { get; set; }

        public string ContactLastName { get; set; } = null!;

        public string ContactNumbrer { get; set; } = null!;

        public string Fax { get; set; } = null!;
    }
}