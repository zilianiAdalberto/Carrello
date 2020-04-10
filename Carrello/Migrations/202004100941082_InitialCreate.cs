namespace Carrello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articoloes",
                c => new
                    {
                        ArticoloId = c.Int(nullable: false, identity: true),
                        ArticoloNome = c.String(),
                    })
                .PrimaryKey(t => t.ArticoloId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        ClienteNome = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
            DropTable("dbo.Articoloes");
        }
    }
}
