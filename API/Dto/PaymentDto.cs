using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class PaymentDto
    {
        public string Id { get; set; }

        public string PaymentMethod { get; set; }

        public string TransactionId { get; set; }
    }
}