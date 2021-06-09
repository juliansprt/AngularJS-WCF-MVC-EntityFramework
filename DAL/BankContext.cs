using DAL.Migrations;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BankContext : DbContext
    {
        public virtual DbSet<Clients> Clients { get; set; }

        public virtual DbSet<ClientAccounts> ClientAccounts { get; set; }

        public virtual DbSet<BankTransaction> BankTransaction { get; set; }


        public BankContext()
            :base("DBContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BankContext, Configuration>("DBContext"));
        }
    }
}
