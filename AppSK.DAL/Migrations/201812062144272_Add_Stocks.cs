namespace AppSK.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Stocks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Marks", "StockId", c => c.Int());
            AddColumn("dbo.Marks", "Factor1", c => c.Double(nullable: false));
            AddColumn("dbo.Marks", "Factor2", c => c.Double(nullable: false));
            AddColumn("dbo.Marks", "Factor3", c => c.Double(nullable: false));
            AddColumn("dbo.Managers", "Type", c => c.Int(nullable: false));
            CreateIndex("dbo.Marks", "StockId");
            AddForeignKey("dbo.Marks", "StockId", "dbo.Stocks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "StockId", "dbo.Stocks");
            DropIndex("dbo.Marks", new[] { "StockId" });
            DropColumn("dbo.Managers", "Type");
            DropColumn("dbo.Marks", "Factor3");
            DropColumn("dbo.Marks", "Factor2");
            DropColumn("dbo.Marks", "Factor1");
            DropColumn("dbo.Marks", "StockId");
            DropTable("dbo.Stocks");
        }
    }
}
