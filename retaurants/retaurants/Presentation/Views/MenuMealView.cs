using restaurants.Business;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Presentation.Views
{
    public class MenuMealView
    {
        private MenuMealBusiness MenuMealBusiness = new MenuMealBusiness();
        private MealBusiness MealBusiness = new MealBusiness();
        private MenuBusiness MenuBusiness = new MenuBusiness();

        /// <summary>
        /// Constructor used by the display.
        /// </summary>
        public MenuMealView()
        {
            Input();
        }

        /// <summary>
        /// Shows all the commands that the user can use.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 15) + "MENUMEAL MENU" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all menumeals");
            Console.WriteLine("2. Add new menumeal");
            Console.WriteLine("3. Fetch menumeal by ID");
            Console.WriteLine("4. Delete menumeal by ID");
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
        /// Aks the user for menumeal characteristics and creates a menumeal with those characteristics, after that adds that menumeal to the table MenuMeals.
        /// </summary>
        private void Add()
        {
            MenuMeal menumeal = new MenuMeal();
            Console.WriteLine("Enter mealId: ");
            menumeal.MealId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter menuId: ");
            menumeal.MenuId = int.Parse(Console.ReadLine());
            MenuMealBusiness.Add(menumeal);
        }

        /// <summary>
        /// Lists all menumeals from the table MenuMeals.
        /// </summary>
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MenuMeal" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<MenuMeal> menumeals = MenuMealBusiness.GetAll();
            Console.WriteLine("MenuId || MealId");
            foreach (MenuMeal menumeal in menumeals)
            {
                Console.WriteLine($"{menumeal.MenuId} || {menumeal.MealId}");
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
        /// Asks the user for id, after that lists the menumeal with that id.
        /// </summary>
        private void Fetch()
        {
            Console.WriteLine("Enter MenuId to fetch: ");
            int MenuId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter MealId to fetch: ");
            int MealId = int.Parse(Console.ReadLine());
            MenuMeal menumeal = MenuMealBusiness.Get(MenuId, MealId);
            if (menumeal != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("MenuId: " + menumeal.MenuId);
                Console.WriteLine("MealId: " + menumeal.MealId);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine(new string(' ', 18) + "Menu" + new string(' ', 17));
                List<Menu> menus = MenuBusiness.GetAll();
                Console.WriteLine("Id || Rating || Type || Language || Link");
                Console.WriteLine($"{menus[MenuId-1].Id} || {menus[MenuId-1].Rating} || {menus[MenuId-1].Type} || {menus[MenuId-1].Language} || {menus[MenuId-1].Link}");
                Console.WriteLine(new string(' ', 18) + "Meal" + new string(' ', 17));
                List<Meal> meals = MealBusiness.GetAll();
                Console.WriteLine("Id || Name || Price || Portionsize || Type");
                Console.WriteLine($"{meals[MealId-1].Id} || {meals[MealId-1].Name} || {meals[MealId-1].Price} || {meals[MealId-1].PortionSize} || {meals[MealId-1].Type}");
            }
            else
            {
                Console.WriteLine("MenuMeal not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that deletes the menumeal with that id.
        /// </summary>
        private void Delete()
        {
            Console.WriteLine("Enter MenuId to delete: ");
            int MenuId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter MealId to delete: ");
            int MealId = int.Parse(Console.ReadLine());
            MenuMealBusiness.Delete(MenuId, MealId);
            Console.WriteLine("Done.");
        }
    }
}
