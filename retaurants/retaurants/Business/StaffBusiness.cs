using restaurants.Data;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Business
{
    public class StaffBusiness
    {
        private RestaurantsContext context;
        /// <summary>
        /// Constructer used in tests
        /// </summary>
        public StaffBusiness(RestaurantsContext restaurantContext)
        {
            this.context = restaurantContext;
        }

        /// <summary>
        /// Constructor used in Presentation layer
        /// </summary>
        public StaffBusiness()
        {
            this.context = new RestaurantsContext();
        }

        /// <summary>
        /// Gets all the staff from the table Staffs
        /// </summary>
        /// <returns>List of all staff</returns>
        public List<Staff> GetAll()
        {
            return context.Staffs.ToList();
        }

        /// <summary>
        /// Gets staff with a given id from the table Staffs
        /// </summary>
        /// <param name="id">Id used to find the staff</param>
        /// <returns>Staff with the given id</returns>
        public Staff Get(int id)
        {
            var staff = context.Staffs.FirstOrDefault(m => m.Id == id);
            return staff;
        }

        /// <summary>
        /// Adds staff to the table Staffs
        /// </summary>
        /// <param name="staff">Staff that will be added to the table</param>
        public void Add(Staff staff)
        {

            context.Staffs.Add(staff);
            context.SaveChanges();

        }

        /// <summary>
        /// Updates the changes for a given staff from the table Staffs
        /// </summary>
        /// <param name="staff">Staff that will be updated</param>
        public void Update(Staff staff)
        {

            var item = context.Staffs.FirstOrDefault(m => m.Id == staff.Id);  
            if (item != null)
            {
                context.Entry(item).CurrentValues.SetValues(staff);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Deletes staff with a given id from the table Staffs
        /// </summary>
        /// <param name="id">Id of the given staff</param>
        public void Delete(int id)
        {
            var item = context.Staffs.Find(id);
            if (item != null)
            {
                context.Staffs.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
