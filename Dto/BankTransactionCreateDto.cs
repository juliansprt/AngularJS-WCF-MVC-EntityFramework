using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class BankTransactionCreateDto
    {
        public Guid AccountOriginId { get; set; }

        public Guid AccountDestinityId { get; set; }

        public decimal Value { get; set; }
    }
}
