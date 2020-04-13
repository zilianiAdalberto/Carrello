namespace Carrello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Cliente_ClienteId", c => c.Int());
            CreateIndex("dbo.Clientes", "Cliente_ClienteId");
            AddForeignKey("dbo.Clientes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "Cliente_ClienteId", "dbo.Clientes");
            DropIndex("dbo.Clientes", new[] { "Cliente_ClienteId" });
            DropColumn("dbo.Clientes", "Cliente_ClienteId");
        }
    }
}
