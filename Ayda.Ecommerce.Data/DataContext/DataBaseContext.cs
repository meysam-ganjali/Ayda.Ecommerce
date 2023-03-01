﻿using Ayda.Ecommerce.Data.DataContext.Tools;
using Ayda.Ecommerce.Domains.Ecommerce;
using Ayda.Ecommerce.Domains.User;
using Microsoft.EntityFrameworkCore;

namespace Ayda.Ecommerce.Data.DataContext;

public class DataBaseContext : DbContext {
    private GenarateHashPass _passwordHasher;
    private string _hashedPassword;
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {
        _passwordHasher = new GenarateHashPass();
        _hashedPassword = _passwordHasher.HashPassword("Admin123!");
    }
    //Auth
    public DbSet<Role> Roles { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    //Ecommerce
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryAttribute> CategoryAttributes { get; set; }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductAttribute> ProductAttributes { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ProductComment> ProductComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys())) {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        modelBuilder.Entity<Role>().HasData(new List<Role>()
        {
            new Role() { Id = 1, Name = RoleSD.Role_Admin },
            new Role() { Id = 2, Name = RoleSD.Role_Employee },
        });

        modelBuilder.Entity<ApplicationUser>().HasData(new List<ApplicationUser>()
        {
            new ApplicationUser()
            {
                Id = 1,
                Email = "ganjalimeysam@gmail.com",
                OrganizationEmail = "GANJALIMEYSAM@GMAIL.COM",
                CreatedDate = DateTime.Now,
                EmailConfirm = true,
                FName = "Meysam",
                LName = "Ganjali",
                Gender = Gender.MAN,
                IsActive = true,
                IsLocked = false,
                PhoneConfirm = true,
                UserPhone = "09187504331",
                RoleId = 1,
                Password =_hashedPassword,

            }
        });
        base.OnModelCreating(modelBuilder);
    }
}