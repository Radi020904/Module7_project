using Microsoft.EntityFrameworkCore;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Data
{
    public class RestaurantsContext : DbContext
    {
        public RestaurantsContext()
        {

        }
        public RestaurantsContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MenuMeal> MenuMeals { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<StaffRestaurant> StaffRestaurants { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer
                    (@"Server=(localdb)\MSSQLLocalDB;Database=Project_Restaurants; Integrated Security=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuMeal>()
                .HasKey(bc => new { bc.MenuId, bc.MealId });
            modelBuilder.Entity<StaffRestaurant>()
                .HasKey(bc => new {bc.RestaurantId, bc.StaffId});
            /*modelBuilder.Entity<MenuMeal>()
                .HasOne(bc => bc.Menu)
                .WithMany()
                .HasForeignKey(bc => bc.MenuId);
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);*/
        }
    }
}
