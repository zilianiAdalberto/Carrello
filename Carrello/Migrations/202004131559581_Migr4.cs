namespace Carrello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClienteArticoloes", "Cliente_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.ClienteArticoloes", "Articolo_ArticoloId", "dbo.Articoloes");
            DropIndex("dbo.ClienteArticoloes", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.ClienteArticoloes", new[] { "Articolo_ArticoloId" });
            AddColumn("dbo.Clientes", "Articolo_ArticoloId", c => c.Int());
            CreateIndex("dbo.Clientes", "Articolo_ArticoloId");
            AddForeignKey("dbo.Clientes", "Articolo_ArticoloId", "dbo.Articoloes", "ArticoloId");
            DropTable("dbo.ClienteArticoloes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClienteArticoloes",
                c => new
                    {
                        Cliente_ClienteId = c.Int(nullable: false),
                        Articolo_ArticoloId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cliente_ClienteId, t.Articolo_ArticoloId });
            
            DropForeignKey("dbo.Clientes", "Articolo_ArticoloId", "dbo.Articoloes");
            DropIndex("dbo.Clientes", new[] { "Articolo_ArticoloId" });
            DropColumn("dbo.Clientes", "Articolo_ArticoloId");
            CreateIndex("dbo.ClienteArticoloes", "Articolo_ArticoloId");
            CreateIndex("dbo.ClienteArticoloes", "Cliente_ClienteId");
            AddForeignKey("dbo.ClienteArticoloes", "Articolo_ArticoloId", "dbo.Articoloes", "ArticoloId", cascadeDelete: true);
            AddForeignKey("dbo.ClienteArticoloes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
        }
    }
}
