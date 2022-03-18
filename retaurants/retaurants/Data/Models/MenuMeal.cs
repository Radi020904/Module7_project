using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Data.Models
{
    public class MenuMeal
    {
        /// <summary>
        /// Foreign Key connected with table Meal
        /// </summary>
        [ForeignKey("Meal")]
        public int MealId { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public Meal Meal { get; set; }
        /// <summary>
        /// Foreign Key connected with table Drivers
        /// </summary>
        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public Menu Menu { get; set; }
        public override string ToString()
        {
            string result = "MenuMeal:\n";
            result += $"{Meal.ToString()}\n";
            result += Menu.ToString();

            return result;
        }
    }
}
