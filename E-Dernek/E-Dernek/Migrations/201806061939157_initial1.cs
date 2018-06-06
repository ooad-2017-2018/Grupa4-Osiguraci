namespace E_Dernek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dernek", "Slika", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dernek", "Slika");
        }
    }
}
