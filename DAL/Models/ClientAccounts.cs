using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ClientAccounts
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public string AccountNro { get; set; }

        public decimal Balance { get; set; }

        [ForeignKey("ClientId")]
        public virtual Clients Client { get; set; }
    }
}
