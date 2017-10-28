namespace BusinessApp_AsgaTech.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleSelected : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserRoles", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.UserRoles", name: "RoleId", newName: "Role_Id");
            RenameIndex(table: "dbo.UserRoles", name: "IX_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.UserRoles", name: "IX_RoleId", newName: "IX_Role_Id");
            AddColumn("dbo.Roles", "Selected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "Selected");
            RenameIndex(table: "dbo.UserRoles", name: "IX_Role_Id", newName: "IX_RoleId");
            RenameIndex(table: "dbo.UserRoles", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.UserRoles", name: "Role_Id", newName: "RoleId");
            RenameColumn(table: "dbo.UserRoles", name: "User_Id", newName: "UserId");
        }
    }
}
