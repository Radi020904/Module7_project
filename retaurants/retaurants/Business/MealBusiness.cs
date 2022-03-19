using restaurants.Data;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Business
{
    public class MealBusiness
    {
        private RestaurantsContext context;

        /// <summary>
        /// Constructor used in Presentation layer
        /// </summary>
        public MealBusiness()
        {
            this.context = new RestaurantsContext();
        }

        /// <summary>
        /// Gets all meals from the table Meals
        /// </summary>
        /// <returns>List of all meals</returns>
        public List<Meal> GetAll()
        {
            return context.Meals.ToList();
        }

        /// <summary>
        /// Gets a meal with a given id from the table Meals
        /// </summary>
        /// <param name="id">Id used to find the meal</param>
        /// <returns>Meal with the given id</returns>
        public Meal Get(int id)
        {
            var meal = context.Meals.FirstOrDefault(m => m.Id == id);
            return meal;
        }

        /// <summary>
        /// Adds a meal to the table Meals
        /// </summary>
        /// <param name="meal">Meal that will be added to the table</param>
        public void Add(Meal meal)
        {

            context.Meals.Add(meal);
            context.SaveChanges();

        }

        /// <summary>
        /// Updates the changes for a given meal from the table Meals
        /// </summary>
        /// <param name="meal">Meal that will be updated</param>
        public void Update(Meal meal)
        {

            var item = context.Meals.FirstOrDefault(m => m.Id == meal.Id);
            if (item != null)
            {
                context.Entry(item).CurrentValues.SetValues(meal);
                context.SaveChanges();
            }
        }
            /// <summary>
            /// Deletes a meal with a given id from the table Meals
            /// </summary>
            /// <param name="id">Id of the given meal</param>
            public void Delete(int id)
            {
                var item = context.Meals.Find(id);
                if (item != null)
                {
                    context.Meals.Remove(item);
                    context.SaveChanges();
                }
            }

    }
}
