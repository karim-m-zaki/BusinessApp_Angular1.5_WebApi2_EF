namespace BusinessApp_AsgaTech.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userRoleUpdate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserRoles");
            AddColumn("dbo.UserRoles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Roles", "RoleName", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AddPrimaryKey("dbo.UserRoles", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserRoles");
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Roles", "RoleName", c => c.String(nullable: false));
            DropColumn("dbo.UserRoles", "Id");
            AddPrimaryKey("dbo.UserRoles", new[] { "UserId", "RoleId" });
        }
    }
}
