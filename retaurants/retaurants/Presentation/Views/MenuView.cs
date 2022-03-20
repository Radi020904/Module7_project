using restaurants.Business;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Presentation.Views
{
    public class MenuView
    {
        private MenuBusiness MenuBusiness = new MenuBusiness();

        /// <summary>
        /// Constructor used by the display.
        /// </summary>
        public MenuView()
        {
            Input();
        }

        /// <summary>
        /// Shows all the commands that the user can use.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 15) + "MENU MENU" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all menus");
            Console.WriteLine("2. Add new menu");
            Console.WriteLine("3. Update menu");
            Console.WriteLine("4. Fetch menu by ID");
            Console.WriteLine("5. Delete menu by ID");
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
            Menu menu = new Menu();
            Console.WriteLine("Enter menu rating: ");
            menu.Rating = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter type: ");
            menu.Type = Console.ReadLine();
            Console.WriteLine("Enter language: ");
            menu.Language = Console.ReadLine();
            Console.WriteLine("Enter link: ");
            menu.Link = Console.ReadLine();
            MenuBusiness.Add(menu);
        }

        /// <summary>
        /// Lists all menus from the table Menus.
        /// </summary>
        private void ListAll()
        {
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
        /// Asks the user for id, after that finds the menu with that id and asks for changes.
        /// </summary>
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Menu menu = MenuBusiness.Get(id);
            if (menu != null)
            {
                Console.WriteLine("Enter rating: ");
                menu.Rating = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter type: ");
                menu.Type = Console.ReadLine();
                Console.WriteLine("Enter language: ");
                menu.Language = Console.ReadLine();
                Console.WriteLine("Enter link: ");
                menu.Link = Console.ReadLine();
                MenuBusiness.Update(menu);
            }
            else
            {
                Console.WriteLine("Menu not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that lists the menu with that id.
        /// </summary>
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Menu menu = MenuBusiness.Get(id);
            if (menu != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + menu.Id);
                Console.WriteLine("Rating: " + menu.Rating);
                Console.WriteLine("Type: " + menu.Type);
                Console.WriteLine("Language: " + menu.Language);
                Console.WriteLine("Link: " + menu.Link);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Menu not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that deletes the menu with that id.
        /// </summary>
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            MenuBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
