using restaurants.Data;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Business
{
    public class StaffRestaurantBusiness
    {
        private RestaurantsContext context;
        /// <summary>
        /// Constructer used in tests
        /// </summary>
        public StaffRestaurantBusiness(RestaurantsContext restaurantContext)
        {
            this.context = restaurantContext;
        }

        /// <summary>
        /// Constructor used in Presentation layer
        /// </summary>
        public StaffRestaurantBusiness()
        {
            this.context = new RestaurantsContext();
        }

        /// <summary>
        /// Gets all staffrestaurants from the table StaffRestaurants
        /// </summary>
        /// <returns>List of all staffrestaurants</returns>
        public List<StaffRestaurant> GetAll()
        {
            return context.StaffRestaurants.ToList();
        }

        /// <summary>
        /// Gets a staffrestaurant with a given id from the table StaffRestaurants
        /// </summary>
        /// <param name="id">Id used to find the staffrestaurant</param>
        /// <returns>Staffrestaurant with the given company</returns>
        public StaffRestaurant Get(int RestaurantId, int StaffId)
        {
            var staffrestaurant = context.StaffRestaurants.FirstOrDefault(m => m.StaffId == StaffId && m.RestaurantId == RestaurantId);
            return staffrestaurant;
        }

        /// <summary>
        /// Adds a staffrestaurant to the table StaffRestaurants
        /// </summary>
        /// <param name="staffrestaurant">Staffrestaurant that will be added to the table</param>
        public void Add(StaffRestaurant staffrestaurant)
        {

            context.StaffRestaurants.Add(staffrestaurant);
            context.SaveChanges();

        }

        /// <summary>
        /// Deletes a staffrestaurants with a given id from the table StaffRestaurants
        /// </summary>
        /// <param name="id">Id of the given staffrestaurant</param>
        public void Delete(int RestaurantId, int StaffId)
        {
            var item = context.StaffRestaurants.FirstOrDefault(m => m.StaffId == StaffId && m.RestaurantId == RestaurantId);
            if (item != null)
            {
                context.StaffRestaurants.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
