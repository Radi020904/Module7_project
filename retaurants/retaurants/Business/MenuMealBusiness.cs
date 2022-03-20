using restaurants.Data;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Business
{
    public class MenuMealBusiness
    {
        private RestaurantsContext context;
        /// <summary>
        /// Constructer used in tests
        /// </summary>
        public MenuMealBusiness(RestaurantsContext restaurantContext)
        {
            this.context = restaurantContext;
        }

        /// <summary>
        /// Constructor used in Presentation layer
        /// </summary>
        public MenuMealBusiness()
        {
            this.context = new RestaurantsContext();
        }

        /// <summary>
        /// Gets all menumeals from the table MenuMeals
        /// </summary>
        /// <returns>List of all menumeals</returns>
        public List<MenuMeal> GetAll()
        {
            return context.MenuMeals.ToList();
        }

        /// <summary>
        /// Gets a menumeal with a given id from the table MenuMeals
        /// </summary>
        /// <param name="id">Id used to find the menumeal</param>
        /// <returns>MenuMeal with the given company</returns>
        public MenuMeal Get(int MenuId, int MealId)
        {
            var menumeal = context.MenuMeals.FirstOrDefault(m => m.MealId  == MealId && m.MenuId == MenuId);
            return menumeal;
        }

        /// <summary>
        /// Adds a menumeal to the table Menumeals
        /// </summary>
        /// <param name="menumeal">MenuMeal that will be added to the table</param>
        public void Add(MenuMeal menumeal)
        {

            context.MenuMeals.Add(menumeal);
            context.SaveChanges();

        }

        /// <summary>
        /// Deletes a menumeal with a given id from the table Menumeals
        /// </summary>
        /// <param name="id">Id of the given menumeal</param>
        public void Delete(int MenuId, int MealId)
        {
            var item = context.MenuMeals.FirstOrDefault(m => m.MealId == MealId && m.MenuId == MenuId);
            if (item != null)
            {
                context.MenuMeals.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
