using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class AccountClientDto
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }

        public string Identification { get; set; }

        public string Bank { get; set; }

        public string AccountNro { get; set; }
    }
}
