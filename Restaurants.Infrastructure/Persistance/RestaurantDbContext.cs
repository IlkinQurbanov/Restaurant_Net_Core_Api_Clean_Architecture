using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using System;

namespace Restaurants.Infrastructure.Persistance
{
    public class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : DbContext(options)
    {
    /*    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) 
        {

        }*/

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }

   /*     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set the connection string for SQL Server
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-15CV0PF\SQLEXPRESS;Database=restaurant;Trusted_Connection=True;TrustServerCertificate=True;");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r => r.Address);
            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);


        }


    }
}
