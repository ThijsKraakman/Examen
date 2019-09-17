namespace Voorraadsysteem_ToolsForEver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MedewerkersCode", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Voorletters", c => c.String());
            AddColumn("dbo.AspNetUsers", "Voorvoegsels", c => c.String());
            AddColumn("dbo.AspNetUsers", "Achternaam", c => c.String());
            AddColumn("dbo.AspNetUsers", "Naam", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Naam");
            DropColumn("dbo.AspNetUsers", "Achternaam");
            DropColumn("dbo.AspNetUsers", "Voorvoegsels");
            DropColumn("dbo.AspNetUsers", "Voorletters");
            DropColumn("dbo.AspNetUsers", "MedewerkersCode");
        }
    }
}
