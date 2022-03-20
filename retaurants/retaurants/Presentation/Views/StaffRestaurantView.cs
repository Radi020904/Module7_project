using restaurants.Business;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Presentation.Views
{
    public class StaffRestaurantView
    {
        private StaffRestaurantBusiness StaffRestaurantBusiness = new StaffRestaurantBusiness();
        private StaffBusiness StaffBusiness = new StaffBusiness();
        private RestaurantBusiness RestaurantBusiness = new RestaurantBusiness();

        /// <summary>
        /// Constructor used by the display.
        /// </summary>
        public StaffRestaurantView()
        {
            Input();
        }

        /// <summary>
        /// Shows all the commands that the user can use.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 15) + "STAFFRESTAURANT MENU" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all staffrestaurants");
            Console.WriteLine("2. Add new staffrestaurant");
            Console.WriteLine("3. Fetch staffrestaurant by ID");
            Console.WriteLine("4. Delete staffrestaurant by ID");
            Console.WriteLine("5. Back to MAIN MENU");
        }

        /// <summary>
        /// Converts the input and does the selected command.
        /// </summary>
        private void Input()
        {

            int command = 0;
            int closedCommandId = 5;
            do
            {
                ShowMenu();
                command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1: ListAll(); break;
                    case 2: Add(); break;
                    case 3: Fetch(); break;
                    case 4: Delete(); break;
                    default: break;
                }
            } while (command != closedCommandId);
        }

        /// <summary>
        /// Aks the user for staffrestaurant characteristics and creates a staffrestaurant with those characteristics, 
        /// after that adds that staffrestaurant to the table StaffRestaurants.
        /// </summary>
        private void Add()
        {
            StaffRestaurant staffrestaurant = new StaffRestaurant();
            Console.WriteLine("Enter RestaurantId: ");
            staffrestaurant.RestaurantId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter StaffId: ");
            staffrestaurant.StaffId = int.Parse(Console.ReadLine());
            StaffRestaurantBusiness.Add(staffrestaurant);
        }

        /// <summary>
        /// Lists all staffrestaurants from the table StaffRestaurants.
        /// </summary>
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "StaffRestaurant" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<StaffRestaurant> staffrestaurants = StaffRestaurantBusiness.GetAll();
            Console.WriteLine("RestaurantId || StaffId");
            foreach (StaffRestaurant staffrestaurant in staffrestaurants)
            {
                Console.WriteLine($"{staffrestaurant.RestaurantId} || {staffrestaurant.StaffId}");
            }
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
            Console.WriteLine(new string(' ', 18) + "Staffs" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<Staff> staffs = StaffBusiness.GetAll();
            Console.WriteLine("Id || FirstName || LastName || Age || Job || Salary");
            foreach (Staff staff in staffs)
            {
                Console.WriteLine($"{staff.Id} || {staff.FirstName} || {staff.LastName} || {staff.Age} || {staff.Job} || {staff.Salary}");
            }
            Console.WriteLine(new string('-', 40));
        }


        /// <summary>
        /// Asks the user for id, after that lists the staffrestaurant with that id.
        /// </summary>
        private void Fetch()
        {
            Console.WriteLine("Enter RestaurantId to fetch: ");
            int RestaurantId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter StaffId to fetch: ");
            int StaffId = int.Parse(Console.ReadLine());
            StaffRestaurant staffrestaurant = StaffRestaurantBusiness.Get(RestaurantId, StaffId);
            if (staffrestaurant != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("RestaurantId: " + staffrestaurant.RestaurantId);
                Console.WriteLine("StaffId: " + staffrestaurant.StaffId);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine(new string(' ', 18) + "Restaurant" + new string(' ', 17));
                List<Restaurant> restaurants = RestaurantBusiness.GetAll();
                Console.WriteLine("Id || Name || Location || MenuId || Capacity || Link");
                Console.WriteLine($"{restaurants[RestaurantId-1].Id} || {restaurants[RestaurantId - 1].Name} || {restaurants[RestaurantId - 1].Location} || {restaurants[RestaurantId - 1].MenuId} || {restaurants[RestaurantId - 1].Capacity} || {restaurants[RestaurantId - 1].Link}");
                Console.WriteLine(new string(' ', 18) + "Staff" + new string(' ', 17));
                List<Staff> staffs = StaffBusiness.GetAll();
                Console.WriteLine("Id || FirstName || LastName || Age || Job || Salary");
                Console.WriteLine($"{staffs[StaffId-1].Id} || {staffs[StaffId - 1].FirstName} || {staffs[StaffId - 1].LastName} || {staffs[StaffId - 1].Age} || {staffs[StaffId - 1].Job} || {staffs[StaffId - 1].Salary}");
            }
            else
            {
                Console.WriteLine("StaffRestaurant not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that deletes the staffrestaurant with that id.
        /// </summary>
        private void Delete()
        {
            Console.WriteLine("Enter RestaurantId to delete: ");
            int RestaurantId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter StaffId to delete: ");
            int StaffId = int.Parse(Console.ReadLine());
            StaffRestaurantBusiness.Delete(RestaurantId, StaffId);
            Console.WriteLine("Done.");
        }
    }
}
