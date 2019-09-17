namespace Voorraadsysteem_ToolsForEver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prijsDecimalToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "InkoopPrijs", c => c.String());
            AlterColumn("dbo.Products", "VerkoopPrijs", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "VerkoopPrijs", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "InkoopPrijs", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
