using restaurants.Data;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Business
{
    public class MenuBusiness
    {
        private RestaurantsContext context;
        /// <summary>
        /// Constructer used in tests
        /// </summary>
        public MenuBusiness(RestaurantsContext restaurantContext)
        {
            this.context = restaurantContext;
        }

        /// <summary>
        /// Constructor used in Presentation layer
        /// </summary>
        public MenuBusiness()
        {
            this.context = new RestaurantsContext();
        }

        /// <summary>
        /// Gets all menus from the table Menus
        /// </summary>
        /// <returns>List of all menus</returns>
        public List<Menu> GetAll()
        {
            return context.Menus.ToList();
        }

        /// <summary>
        /// Gets a menu with a given id from the table Menus
        /// </summary>
        /// <param name="id">Id used to find the menu</param>
        /// <returns>Menu with the given id</returns>
        public Menu Get(int id)
        {
            var menu = context.Menus.FirstOrDefault(m => m.Id == id);
            return menu;
        }

        /// <summary>
        /// Adds a menu to the table Menus
        /// </summary>
        /// <param name="menu">Menu that will be added to the table</param>
        public void Add(Menu menu)
        {

            context.Menus.Add(menu);
            context.SaveChanges();

        }

        /// <summary>
        /// Updates the changes for a given menu from the table Menus
        /// </summary>
        /// <param name="menu">Menu that will be updated</param>
        public void Update(Menu menu)
        {

            var item = context.Menus.FirstOrDefault(m => m.Id == menu.Id);
            if (item != null)
            {
                context.Entry(item).CurrentValues.SetValues(menu);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Deletes a menu with a given id from the table Menus
        /// </summary>
        /// <param name="id">Id of the given menu</param>
        public void Delete(int id)
        {
            var item = context.Menus.Find(id);
            if (item != null)
            {
                context.Menus.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
