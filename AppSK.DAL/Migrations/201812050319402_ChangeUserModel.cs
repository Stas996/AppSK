namespace AppSK.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
            AddColumn("dbo.Users", "DateOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.Experts", "FirstName");
            DropColumn("dbo.Experts", "LastName");
            DropColumn("dbo.Experts", "DateOfBirth");
            DropColumn("dbo.Managers", "FirstName");
            DropColumn("dbo.Managers", "LastName");
            DropColumn("dbo.Managers", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Managers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Managers", "LastName", c => c.String());
            AddColumn("dbo.Managers", "FirstName", c => c.String());
            AddColumn("dbo.Experts", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Experts", "LastName", c => c.String());
            AddColumn("dbo.Experts", "FirstName", c => c.String());
            DropColumn("dbo.Users", "DateOfBirth");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
        }
    }
}
