namespace Carrello.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articoli",
                c => new
                    {
                        ArticoloId = c.Int(nullable: false, identity: true),
                        ArticoloNome = c.String(),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticoloId);
            
            CreateTable(
                "dbo.Clienti",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        ClienteNome = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clienti");
            DropTable("dbo.Articoli");
        }
    }
}
