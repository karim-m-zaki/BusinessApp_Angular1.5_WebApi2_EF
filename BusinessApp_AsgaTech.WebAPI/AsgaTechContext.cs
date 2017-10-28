﻿using System.Data.Entity;

public class AsgaTechContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    //
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public AsgaTechContext() : base("name=AsgaTechContext")
    {
    }

    public System.Data.Entity.DbSet<BusinessApp_AsgaTech.Models.Models.User> Users { get; set; }

    public System.Data.Entity.DbSet<BusinessApp_AsgaTech.Models.Models.Role> Roles { get; set; }

    public System.Data.Entity.DbSet<BusinessApp_AsgaTech.Models.Models.UserRole> UserRole { get; set; }
}