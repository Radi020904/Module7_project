using restaurants.Business;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Presentation.Views
{
    public class RestaurantView
    {
        private RestaurantBusiness RestaurantBusiness = new RestaurantBusiness();
        private MenuBusiness MenuBusiness = new MenuBusiness();

        /// <summary>
        /// Constructor used by the display.
        /// </summary>
        public RestaurantView()
        {
            Input();
        }

        /// <summary>
        /// Shows all the commands that the user can use.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 15) + "RESTAURANT MENU" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all restaurants");
            Console.WriteLine("2. Add new restaurant");
            Console.WriteLine("3. Update restaurant");
            Console.WriteLine("4. Fetch restaurant by ID");
            Console.WriteLine("5. Delete restaurant by ID");
            Console.WriteLine("6. Back to MAIN MENU");
        }

        /// <summary>
        /// Converts the input and does the selected command.
        /// </summary>
        private void Input()
        {

            int command = 0;
            int closedCommandId = 6;
            do
            {
                ShowMenu();
                command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1: ListAll(); break;
                    case 2: Add(); break;
                    case 3: Update(); break;
                    case 4: Fetch(); break;
                    case 5: Delete(); break;
                    default: break;
                }
            } while (command != closedCommandId);
        }

        /// <summary>
        /// Aks the user for restaurant characteristics and creates a restaurant with those characteristics, after that adds that restaurant
        /// to the table Restaurants.
        /// </summary>
        private void Add()
        {
            Restaurant restaurant = new Restaurant();
            Console.WriteLine("Enter restaurant name: ");
            restaurant.Name = Console.ReadLine();
            Console.WriteLine("Enter location: ");
            restaurant.Location = Console.ReadLine();
            Console.WriteLine("Enter MenuId: ");
            restaurant.MenuId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter capacity: ");
            restaurant.Capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter link: ");
            restaurant.Link = Console.ReadLine();
            RestaurantBusiness.Add(restaurant);
        }

        /// <summary>
        /// Lists all restaurants from the table Restaurants.
        /// </summary>
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Restaurants" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<Restaurant> restaurants = RestaurantBusiness.GetAll();
            Console.WriteLine("Id || Name || Location || MenuId || Capacity || Link");
            foreach (Restaurant restaurant in restaurants)
            {
                Console.WriteLine($"{restaurant.Id} || {restaurant.Name} || {restaurant.Location} || {restaurant.MenuId} || {restaurant.Capacity} || {restaurant.Link}");
            }
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Menus" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<Menu> menus = MenuBusiness.GetAll();
            Console.WriteLine("Id || Rating || Type || Language || Link");
            foreach (Menu menu in menus)
            {
                Console.WriteLine($"{menu.Id} || {menu.Rating} || {menu.Type} || {menu.Language} || {menu.Link}");
            }
            Console.WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Asks the user for id, after that finds the restaurant with that id and asks for changes.
        /// </summary>
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Restaurant restaurant = RestaurantBusiness.Get(id);
            if (restaurant != null)
            {
                Console.WriteLine("Enter name: ");
                restaurant.Name = Console.ReadLine();
                Console.WriteLine("Enter location: ");
                restaurant.Location = Console.ReadLine();
                Console.WriteLine("Enter MenuId: ");
                restaurant.MenuId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter capacity: ");
                restaurant.Capacity = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter link: ");
                restaurant.Link = Console.ReadLine();
                RestaurantBusiness.Update(restaurant);
            }
            else
            {
                Console.WriteLine("Restaurant not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that lists the restaurant with that id.
        /// </summary>
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Restaurant restaurant = RestaurantBusiness.Get(id);
            if (restaurant != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + restaurant.Id);
                Console.WriteLine("Name: " + restaurant.Name);
                Console.WriteLine("Location: " + restaurant.Location);
                //Console.WriteLine("MenuId: " + restaurant.MenuId);
                Console.WriteLine("Capacity: " + restaurant.Capacity);
                Console.WriteLine("Link: " + restaurant.Link);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Restaurant not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that deletes the restaurant with that id.
        /// </summary>
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            RestaurantBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
