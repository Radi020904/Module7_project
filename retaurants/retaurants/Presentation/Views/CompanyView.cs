using restaurants.Business;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Presentation.Views
{
    public class CompanyView
    {
        private CompanyBusiness CompanyBusiness = new CompanyBusiness();
        private RestaurantBusiness RestaurantBusiness = new RestaurantBusiness();

        /// <summary>
        /// Constructor used by the display.
        /// </summary>
        public CompanyView()
        {
            Input();
        }

        /// <summary>
        /// Shows all the commands that the user can use.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 15) + "COMPANY MENU" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all companies");
            Console.WriteLine("2. Add new company");
            Console.WriteLine("3. Update company");
            Console.WriteLine("4. Fetch company by ID");
            Console.WriteLine("5. Delete company by ID");
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
        /// Aks the user for menu characteristics and creates a menu with those characteristics, after that adds that menu to the table Menus.
        /// </summary>
        private void Add()
        {
            Company company = new Company();
            Console.WriteLine("Enter company name: ");
            company.Name = Console.ReadLine();
            Console.WriteLine("Enter owner name: ");
            company.OwnerName = Console.ReadLine();
            Console.WriteLine("Enter creation date: ");
            company.CreationDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter restaurant id: ");
            company.RestaurantId = int.Parse(Console.ReadLine());
            CompanyBusiness.Add(company);
        }

        /// <summary>
        /// Lists all companies from the table Companies.
        /// </summary>
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Companies" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<Company> companies = CompanyBusiness.GetAll();
            Console.WriteLine("Id || Name || OwnerName || CreationDate || RestaurantId");
            foreach (Company company in companies)
            {
                Console.WriteLine($"{company.Id} || {company.Name} || {company.OwnerName} || {company.CreationDate} || {company.RestaurantId}");
            }
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Restaurants" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<Restaurant> restaurants = RestaurantBusiness.GetAll();
            Console.WriteLine("Id || Name || Location || MenuId || Capacity || Link");
            foreach (Restaurant restaurant in restaurants)
            {
                Console.WriteLine($"{restaurant.Id} || {restaurant.Name} || {restaurant.Location} ||  || {restaurant.Capacity} || {restaurant.Link}");
            }
            Console.WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Asks the user for id, after that finds the company with that id and asks for changes.
        /// </summary>
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Company company = CompanyBusiness.Get(id);
            if (company != null)
            {
                Console.WriteLine("Enter company name: ");
                company.Name = Console.ReadLine();
                Console.WriteLine("Enter owner name: ");
                company.OwnerName = Console.ReadLine();
                Console.WriteLine("Enter creation date: ");
                company.CreationDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter restaurant id: ");
                company.RestaurantId = int.Parse(Console.ReadLine());
                CompanyBusiness.Update(company);
            }
            else
            {
                Console.WriteLine("Company not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that lists the company with that id.
        /// </summary>
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Company company = CompanyBusiness.Get(id);
            if (company != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + company.Id);
                Console.WriteLine("Name: " + company.Name);
                Console.WriteLine("OwnerName: " + company.OwnerName);
                Console.WriteLine("CreationDate: " + company.CreationDate);
                Console.WriteLine("Restaurant: " + company.RestaurantId);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Company not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that deletes the company with that id.
        /// </summary>
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            CompanyBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
