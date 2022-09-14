using CrudExample.Models.EntityModels;
using CrudExample.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrudExample.Models.Database
{
    public class DatabaseConntext:IdentityDbContext<AppUser,AppRole,int>
    {
        public DatabaseConntext(DbContextOptions<DatabaseConntext>options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>(b => b.ToTable("AppUsers"));
            builder.Entity<AppRole>(b => b.ToTable("AppRoles"));
        }
    }
}
