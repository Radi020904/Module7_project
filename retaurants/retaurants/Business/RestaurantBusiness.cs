using restaurants.Data;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Business
{
    public class RestaurantBusiness
    {
        private RestaurantsContext context;
        /// <summary>
        /// Constructer used in tests
        /// </summary>
        public RestaurantBusiness(RestaurantsContext restaurantContext)
        {
            this.context = restaurantContext;
        }

        /// <summary>
        /// Constructor used in Presentation layer
        /// </summary>
        public RestaurantBusiness()
        {
            this.context = new RestaurantsContext();
        }

        /// <summary>
        /// Gets all restaurants from the table Restaurants
        /// </summary>
        /// <returns>List of all meals</returns>
        public List<Restaurant> GetAll()
        {
            return context.Restaurants.ToList();
        }

        /// <summary>
        /// Gets a restaurant with a given id from the table Restaurants
        /// </summary>
        /// <param name="id">Id used to find the restaurant</param>
        /// <returns>Restaurant with the given id</returns>
        public Restaurant Get(int id)
        {
            var restaurant = context.Restaurants.FirstOrDefault(m => m.Id == id);
            return restaurant;
        }

        /// <summary>
        /// Adds a restaurant to the table Restaurants
        /// </summary>
        /// <param name="restaurant">Restaurant that will be added to the table</param>
        public void Add(Restaurant restaurant)
        {

            context.Restaurants.Add(restaurant);
            context.SaveChanges();

        }

        /// <summary>
        /// Updates the changes for a given restaurant from the table Restaurants
        /// </summary>
        /// <param name="restaurant">Restaurant that will be updated</param>
        public void Update(Restaurant restaurant)
        {

            var item = context.Restaurants.FirstOrDefault(m => m.Id == restaurant.Id);
            if (item != null)
            {
                context.Entry(item).CurrentValues.SetValues(restaurant);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Deletes a restaurant with a given id from the table Restaurants
        /// </summary>
        /// <param name="id">Id of the given restaurant</param>
        public void Delete(int id)
        {
            var item = context.Restaurants.Find(id);
            if (item != null)
            {
                context.Restaurants.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
