namespace AppSK.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Marks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Marks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Marks", new[] { "ProjectId" });
            AlterColumn("dbo.Marks", "ProjectId", c => c.Int());
            CreateIndex("dbo.Marks", "ProjectId");
            AddForeignKey("dbo.Marks", "ProjectId", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Marks", new[] { "ProjectId" });
            AlterColumn("dbo.Marks", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Marks", "ProjectId");
            AddForeignKey("dbo.Marks", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
