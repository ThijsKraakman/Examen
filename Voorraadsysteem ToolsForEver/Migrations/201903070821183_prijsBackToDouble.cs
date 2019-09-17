namespace Voorraadsysteem_ToolsForEver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prijsBackToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "InkoopPrijs", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "VerkoopPrijs", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "VerkoopPrijs", c => c.String());
            AlterColumn("dbo.Products", "InkoopPrijs", c => c.String());
        }
    }
}
