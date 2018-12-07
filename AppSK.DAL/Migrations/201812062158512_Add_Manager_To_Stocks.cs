namespace AppSK.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Manager_To_Stocks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "ManagerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Stocks", "ManagerId");
            AddForeignKey("dbo.Stocks", "ManagerId", "dbo.Managers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "ManagerId", "dbo.Managers");
            DropIndex("dbo.Stocks", new[] { "ManagerId" });
            DropColumn("dbo.Stocks", "ManagerId");
        }
    }
}
