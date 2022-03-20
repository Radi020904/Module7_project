using restaurants.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Views
{
    public class Display
    {
        /// <summary>
        /// Constructor for the display.
        /// </summary>
        public Display()
        {
            Input();
        }

        /// <summary>
        /// Shows the user all the tables he can access.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 15) + "MAIN MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Meal");
            Console.WriteLine("2. Menu");
            Console.WriteLine("3. MenuMeal");
            Console.WriteLine("4. Restaurant");
            Console.WriteLine("5. Staff");
            Console.WriteLine("6. StaffRestaurant");
            Console.WriteLine("7. Company");
            Console.WriteLine("8. Exit");
        }

        /// <summary>
        /// Converts the input into the wanted table.
        /// </summary>
        private void Input()
        {

            int command = 0;
            int closedCommandId = 8;
            do
            {
                ShowMenu();
                command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1: Meals(); break;
                    case 2: Menus(); break;
                    case 3: MenuMeals(); break;
                    case 4: Restaurants(); break;
                    case 5: Staffs(); break;
                    case 6: StaffRestaurants(); break;
                    case 7: Companies(); break;
                    default: break;
                }
            } while (command != closedCommandId);
        }

        /// <summary>
        /// Creates a meal view.
        /// </summary>
        private void Meals()
        {
            MealView mealView = new MealView();
        }

        /// <summary>
        /// Creates a menu view.
        /// </summary>
        private void Menus()
        {
            MenuView menuView = new MenuView();
        }

        /// <summary>
        /// Creates a menumeal view.
        /// </summary>
        private void MenuMeals()
        {
            MenuMealView menumealView = new MenuMealView();
        }

        /// <summary>
        /// Creates a restaurant view.
        /// </summary>
        private void Restaurants()
        {
            RestaurantView restaurantView = new RestaurantView();
        }

        /// <summary>
        /// Creates a staff view.
        /// </summary>
        private void Staffs()
        {
            StaffView staffView = new StaffView();
        }

        /// <summary>
        /// Creates a staffrestaurant view.
        /// </summary>
        private void StaffRestaurants()
        {
            StaffRestaurantView staffRestaurantView = new StaffRestaurantView();
        }

        /// <summary>
        /// Creates a company view.
        /// </summary>
        private void Companies()
        {
            CompanyView orderView = new CompanyView();
        }
    }
}
