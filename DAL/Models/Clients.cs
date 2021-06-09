using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Clients
    {
        public Clients()
        {
            Accounts = new HashSet<ClientAccounts>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string BankName { get; set; }

        public virtual ICollection<ClientAccounts> Accounts { get; set; }
    }

}
