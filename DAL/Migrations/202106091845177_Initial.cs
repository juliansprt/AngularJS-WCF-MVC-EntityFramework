namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankTransactions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdAccountOrigin = c.Guid(nullable: false),
                        IdAccountDestinity = c.Guid(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientAccounts", t => t.IdAccountDestinity, cascadeDelete: true)
                .ForeignKey("dbo.ClientAccounts", t => t.IdAccountOrigin, cascadeDelete: true)
                .Index(t => t.IdAccountOrigin)
                .Index(t => t.IdAccountDestinity);
            
            CreateTable(
                "dbo.ClientAccounts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClientId = c.Guid(nullable: false),
                        AccountNro = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Identification = c.String(),
                        Name = c.String(),
                        BankName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankTransactions", "IdAccountOrigin", "dbo.ClientAccounts");
            DropForeignKey("dbo.BankTransactions", "IdAccountDestinity", "dbo.ClientAccounts");
            DropForeignKey("dbo.ClientAccounts", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientAccounts", new[] { "ClientId" });
            DropIndex("dbo.BankTransactions", new[] { "IdAccountDestinity" });
            DropIndex("dbo.BankTransactions", new[] { "IdAccountOrigin" });
            DropTable("dbo.Clients");
            DropTable("dbo.ClientAccounts");
            DropTable("dbo.BankTransactions");
        }
    }
}
