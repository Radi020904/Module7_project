using restaurants.Business;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Presentation.Views
{
    public class MealView
    {
        private MealBusiness MealBusiness = new MealBusiness();

        /// <summary>
        /// Constructor used by the display.
        /// </summary>
        public MealView()
        {
            Input();
        }

        /// <summary>
        /// Shows all the commands that the user can use.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 15) + "MEAL MENU" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all meals");
            Console.WriteLine("2. Add new meal");
            Console.WriteLine("3. Update meal");
            Console.WriteLine("4. Fetch meal by ID");
            Console.WriteLine("5. Delete meal by ID");
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
        /// Aks the user for meal characteristics and creates a meal with those characteristics, after that adds that meal to the table Meals.
        /// </summary>
        private void Add()
        {
            Meal meal = new Meal();
            Console.WriteLine("Enter meal name: ");
            meal.Name = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            meal.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter portionsize(g): ");
            meal.PortionSize = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter type: ");
            meal.Type = Console.ReadLine();
            MealBusiness.Add(meal);
        }

        /// <summary>
        /// Lists all meals from the table Meals.
        /// </summary>
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Meals" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<Meal> meals = MealBusiness.GetAll();
            Console.WriteLine("Id || Name || Price || Portionsize || Type");
            foreach (Meal meal in meals)
            {
                Console.WriteLine($"{meal.Id} || {meal.Name} || {meal.Price} || {meal.PortionSize} || {meal.Type}");
            }
            Console.WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Asks the user for id, after that finds the meal with that id and asks for changes.
        /// </summary>
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Meal meal = MealBusiness.Get(id);
            if (meal != null)
            {
                Console.WriteLine("Enter name: ");
                meal.Name = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                meal.Price = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter portionsize: ");
                meal.PortionSize = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter type: ");
                meal.Type = Console.ReadLine();
                MealBusiness.Update(meal);
            }
            else
            {
                Console.WriteLine("Meal not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that lists the meal with that id.
        /// </summary>
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Meal meal = MealBusiness.Get(id);
            if (meal != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + meal.Id);
                Console.WriteLine("Name: " + meal.Name);
                Console.WriteLine("Price: " + meal.Price);
                Console.WriteLine("Portionsize: " + meal.PortionSize);
                Console.WriteLine("Type: " + meal.Type);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that deletes the meal with that id.
        /// </summary>
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            MealBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
