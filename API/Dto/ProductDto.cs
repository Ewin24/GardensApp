using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class ProductDto
    {
         public string Id { get;set;  }

        public string Name { get;set;  }

        public string ProductLine { get;set;  } 

        public string Dimensions { get;set;  }
    }
}