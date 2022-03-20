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
            modelBuilder.Entity<Meal>().HasData(new Meal { Id = 1, Name = " Black Forest Gateau", PortionSize = 150, Price = 5.50, Type = "Cake" },
                new Meal { Id = 3, Name = "Beer Ice Cream", PortionSize = 150, Price = 3.40, Type = "Icecream" },
                new Meal { Id = 4, Name = "Blue Heaven", PortionSize = 100, Price = 3.10, Type = "Icecream" },
                new Meal { Id = 5, Name = "Brown Bread", PortionSize = 200, Price = 4.40, Type = "Icecream" },
                new Meal { Id = 6, Name = "Chocolate Whip", PortionSize = 300, Price = 4.10, Type = "Chocolates" },
                new Meal { Id = 7, Name = "McChicken", PortionSize = 400, Price = 8.00, Type = "Burger" },
                new Meal { Id = 8, Name = "McSpicy", PortionSize = 450, Price = 8.10, Type = "Burger" },
                new Meal { Id = 9, Name = "BigMac", PortionSize = 600, Price = 10.40, Type = "Burger" },
                new Meal { Id = 10, Name = "CheeseBurger", PortionSize = 500, Price = 9.00, Type = "Burger" },
                new Meal { Id = 11, Name = "McNuggets", PortionSize = 400, Price = 8.00, Type = "nuggets" },
                new Meal { Id = 12, Name = "Mojito", PortionSize = 100, Price = 10.00, Type = "Cocktail" },
                new Meal { Id = 13, Name = "Martini", PortionSize = 90, Price = 12.00, Type = "Cocktail" },
                new Meal { Id = 14, Name = "Cuba Libre", PortionSize = 80, Price = 10.00, Type = "Cocktail" },
                new Meal { Id = 15, Name = "Gin Tonic", PortionSize = 95, Price = 11.00, Type = "Cocktail" },
                new Meal { Id = 16, Name = "Sex On The Beach", PortionSize = 110, Price = 12.00, Type = "Cocktail" },
                new Meal { Id = 17, Name = "Durum Doner", PortionSize = 300, Price = 4.30, Type = "Doner" },
                new Meal { Id = 18, Name = "Ekmek Doner", PortionSize = 340, Price = 5.10, Type = "Doner" },
                new Meal { Id = 19, Name = "Tabak Doner", PortionSize = 420, Price = 6.00, Type = "Doner" },
                new Meal { Id = 20, Name = "Iskender Doner", PortionSize = 380, Price = 6.00, Type = "Doner" },
                new Meal { Id = 21, Name = "Lahmacun", PortionSize = 210, Price = 3.50, Type = "pide" });

            modelBuilder.Entity<Menu>().HasData(new Menu { Id = 1, Language = "bulgarian", Link = "https://martisbakery/PinchOfSalt/menu.com", Rating = 9.0, Type = "Dessert" },
                new Menu { Id = 2, Language = "english", Link = "https://atasmcdonalds/HaskovoMcDonald/menu.com", Rating = 8.0, Type = "Fast Food" },
                new Menu { Id = 3, Language = "spanish", Link = "https://radisbar/Sense/menu.com", Rating = 8.4, Type = "Cocktail" },
                new Menu { Id = 4, Language = "turkish", Link = "https://ganisdoner/HisarDoner/menu.com", Rating = 9.5, Type = "Fast Food" });

            modelBuilder.Entity<MenuMeal>().HasData(new MenuMeal { MenuId = 1, MealId = 1 },
                new MenuMeal { MenuId = 1, MealId = 3 },
                new MenuMeal { MenuId = 1, MealId = 4 },
                new MenuMeal { MenuId = 1, MealId = 5 },
                new MenuMeal { MenuId = 1, MealId = 6 },
                new MenuMeal { MenuId = 2, MealId = 7 },
                new MenuMeal { MenuId = 2, MealId = 8 },
                new MenuMeal { MenuId = 2, MealId = 9 },
                new MenuMeal { MenuId = 2, MealId = 10 },
                new MenuMeal { MenuId = 2, MealId = 11 },
                new MenuMeal { MenuId = 3, MealId = 12 },
                new MenuMeal { MenuId = 3, MealId = 13 },
                new MenuMeal { MenuId = 3, MealId = 14 },
                new MenuMeal { MenuId = 3, MealId = 15 },
                new MenuMeal { MenuId = 3, MealId = 16 },
                new MenuMeal { MenuId = 4, MealId = 17 },
                new MenuMeal { MenuId = 4, MealId = 18 },
                new MenuMeal { MenuId = 4, MealId = 19 },
                new MenuMeal { MenuId = 4, MealId = 20 },
                new MenuMeal { MenuId = 4, MealId = 21 });

            modelBuilder.Entity<Restaurant>().HasData(new Restaurant { Id = 1, Name = "PinchOfSalt", MenuId = 1, Location = "Haskovo", Capacity = 50, Link = "https://martisbakery/PinchOfSalt.com" },
                new Restaurant { Id = 2, Name = "HaskovoMcDonald", MenuId = 2, Location = "Haskovo", Capacity = 40, Link = "https://atasmcdonalds/HaskovoMcDonald.com" },
                new Restaurant { Id = 3, Name = "Sense", MenuId = 3, Location = "Barcelona", Capacity = 200, Link = "https://radisbar/Sense.com" },
                new Restaurant { Id = 4, Name = "HisarDoner", MenuId = 4, Location = "Istanbul", Capacity = 30, Link = "https://ganisdoner/HisarDoner.com" });

            modelBuilder.Entity<Company>().HasData(new Company { Id = 1, Name = "martisbakery", OwnerName = "Marti", CreationDate = new DateTime(2005, 04, 02), RestaurantId = 1 },
                new Company { Id = 2, Name = "atasmcdonalds", OwnerName = "Ata", CreationDate = new DateTime(2009, 03, 01), RestaurantId = 2 },
                new Company { Id = 3, Name = "radisbar", OwnerName = "Radi", CreationDate = new DateTime(2004, 08, 02), RestaurantId = 3 },
                new Company { Id = 4, Name = "ganisdoner", OwnerName = "Gani", CreationDate = new DateTime(2003, 01, 23), RestaurantId = 4 });

            modelBuilder.Entity<Staff>().HasData(new Staff { Id = 1, FirstName = "Samuel", LastName = "Umtiti", Age = 28, Job = "Chef", Salary = 900 },
                new Staff { Id = 2, FirstName = "Martin", LastName = "Braithwaite", Age = 30, Job = "Waiter", Salary = 600 },
                new Staff { Id = 3, FirstName = "Kylian", LastName = "Mbappe", Age = 23, Job = "Chef", Salary = 1000 },
                new Staff { Id = 4, FirstName = "Erling", LastName = "Halland", Age = 21, Job = "Waiter", Salary = 800 },
                new Staff { Id = 5, FirstName = "Lionel", LastName = "Messi", Age = 34, Job = "Bartender", Salary = 1100 },
                new Staff { Id = 6, FirstName = "Luis", LastName = "Suarez", Age = 35, Job = "Waiter", Salary = 800 },
                new Staff { Id = 7, FirstName = "Sergio", LastName = "Ramos", Age = 35, Job = "Dunerman", Salary = 1000 },
                new Staff { Id = 8, FirstName = "Carlos", LastName = "Casemiro", Age = 30, Job = "Waiter", Salary = 700 });

            modelBuilder.Entity<StaffRestaurant>().HasData(new StaffRestaurant { RestaurantId = 1, StaffId = 1 },
                new StaffRestaurant { RestaurantId = 1, StaffId = 2 },
                new StaffRestaurant { RestaurantId = 2, StaffId = 3 },
                new StaffRestaurant { RestaurantId = 2, StaffId = 4 },
                new StaffRestaurant { RestaurantId = 3, StaffId = 5 },
                new StaffRestaurant { RestaurantId = 3, StaffId = 6 },
                new StaffRestaurant { RestaurantId = 4, StaffId = 7 },
                new StaffRestaurant { RestaurantId = 4, StaffId = 8 });

        }
    }
}
