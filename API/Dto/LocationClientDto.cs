using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class LocationClientDto
    {
        public int Id { get; set; }

        public string TipoDeVia { get; set; }

        public short NumeroPri { get; set; }

        public string Letra { get; set; }

        public string Bis { get; set; }
    }
}