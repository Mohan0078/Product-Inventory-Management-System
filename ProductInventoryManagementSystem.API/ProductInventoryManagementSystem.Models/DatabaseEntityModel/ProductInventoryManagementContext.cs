﻿using Microsoft.EntityFrameworkCore;

namespace ProductInventoryManagementSystem.Model.DatabaseEntityModel
{
    public class ProductInventoryManagementDbContext : DbContext
    {
        public ProductInventoryManagementDbContext(DbContextOptions<ProductInventoryManagementDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
