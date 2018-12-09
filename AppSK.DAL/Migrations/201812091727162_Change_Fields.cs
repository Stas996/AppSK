namespace AppSK.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Fields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stocks", "FinishDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stocks", "Investments", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Projects", "Investments", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Stocks", "PurchaseDate");
            DropColumn("dbo.Stocks", "SaleDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "SaleDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stocks", "PurchaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "Investments", c => c.Int(nullable: false));
            DropColumn("dbo.Stocks", "Investments");
            DropColumn("dbo.Stocks", "FinishDate");
            DropColumn("dbo.Stocks", "StartDate");
        }
    }
}
