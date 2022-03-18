using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Data.Models
{
    public class StaffRestaurant
    {
        /// <summary>
        /// Foreign Key connected with table Drivers
        /// </summary>
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public Restaurant Restaurant { get; set; }
        /// <summary>
        /// Foreign Key connected with table Drivers
        /// </summary>
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public Staff Staff { get; set; }
        public override string ToString()
        {
            string result = "StaffRestaurant:\n";
            result += $"{Restaurant.ToString()}\n";
            result += Staff.ToString();
            return result;
        }
    }
}
