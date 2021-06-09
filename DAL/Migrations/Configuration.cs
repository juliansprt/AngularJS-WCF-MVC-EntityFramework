namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.BankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.BankContext context)
        {
            if(context.Clients.Count() == 0)
            {

                List<Clients> clients = new List<Clients>()
                {
                    new Clients()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Juan Perez",
                        BankName = "Finandina",
                        Identification = "654321",
                        Accounts = new List<ClientAccounts>()
                        {
                            new ClientAccounts()
                            {
                                AccountNro = "7899887",
                                Balance = 1000000,
                                Id = Guid.NewGuid()
                            },
                            new ClientAccounts()
                            {
                                AccountNro = "8899987",
                                Balance = 0,
                                Id = Guid.NewGuid()
                            },
                        }
                    },
                    new Clients()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Andres Acosta",
                        BankName = "BBVA",
                        Identification = "123456",
                        Accounts = new List<ClientAccounts>()
                        {
                            new ClientAccounts()
                            {
                                AccountNro = "8898877",
                                Balance = 500000,
                                Id = Guid.NewGuid()
                            }
                        }
                    },
                };

                foreach (var item in clients)
                {
                    context.Clients.Add(item);
                }

            }
            base.Seed(context);
        }
    }
}
