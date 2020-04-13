namespace Carrello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClienteArticoloes",
                c => new
                    {
                        Cliente_ClienteId = c.Int(nullable: false),
                        Articolo_ArticoloId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cliente_ClienteId, t.Articolo_ArticoloId })
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Articoloes", t => t.Articolo_ArticoloId, cascadeDelete: true)
                .Index(t => t.Cliente_ClienteId)
                .Index(t => t.Articolo_ArticoloId);
            
            AddColumn("dbo.Articoloes", "ClienteId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClienteArticoloes", "Articolo_ArticoloId", "dbo.Articoloes");
            DropForeignKey("dbo.ClienteArticoloes", "Cliente_ClienteId", "dbo.Clientes");
            DropIndex("dbo.ClienteArticoloes", new[] { "Articolo_ArticoloId" });
            DropIndex("dbo.ClienteArticoloes", new[] { "Cliente_ClienteId" });
            DropColumn("dbo.Articoloes", "ClienteId");
            DropTable("dbo.ClienteArticoloes");
        }
    }
}
