namespace E_Dernek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dernek",
                c => new
                    {
                        IDDerneka = c.Int(nullable: false, identity: true),
                        IDLokala = c.Int(nullable: false),
                        Kapacitet = c.Int(nullable: false),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.IDDerneka);
            
            CreateTable(
                "dbo.Lokal",
                c => new
                    {
                        IDLokala = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Adresa = c.String(),
                        Broj = c.String(),
                    })
                .PrimaryKey(t => t.IDLokala);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lokal");
            DropTable("dbo.Dernek");
        }
    }
}
