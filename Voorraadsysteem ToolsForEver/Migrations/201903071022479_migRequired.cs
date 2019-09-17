namespace Voorraadsysteem_ToolsForEver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fabrikants", "Naam", c => c.String(nullable: false));
            AlterColumn("dbo.Fabrikants", "Telefoonnummer", c => c.String(nullable: false));
            AlterColumn("dbo.Locaties", "Adres", c => c.String(nullable: false));
            AlterColumn("dbo.Locaties", "Postcode", c => c.String(nullable: false));
            AlterColumn("dbo.Locaties", "Plaats", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locaties", "Plaats", c => c.String());
            AlterColumn("dbo.Locaties", "Postcode", c => c.String());
            AlterColumn("dbo.Locaties", "Adres", c => c.String());
            AlterColumn("dbo.Fabrikants", "Telefoonnummer", c => c.String());
            AlterColumn("dbo.Fabrikants", "Naam", c => c.String());
        }
    }
}
