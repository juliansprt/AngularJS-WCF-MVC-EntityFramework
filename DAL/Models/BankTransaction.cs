using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BankTransaction
    {
        [Key]
        public Guid Id { get; set; }

        public Guid IdAccountOrigin { get; set; }

        public Guid IdAccountDestinity { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        [ForeignKey("IdAccountOrigin")]
        public virtual ClientAccounts AccountOrigin { get; set; }

        [ForeignKey("IdAccountDestinity")]
        public virtual ClientAccounts AccountDestinity { get; set; }
    }
}
