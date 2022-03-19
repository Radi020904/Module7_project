using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Data.Models
{
    public class Meal
    {
        

        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "meal name is too long!")]
        public string Name { get; set; }
        [Required]
        [Range(typeof(double), "0.99", "99.99")]
        public double Price { get; set; }
        [Required]
        [Range(typeof(double), "0.99", "999.99")]
        public double PortionSize { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "meal type is too long")]
        public string Type { get; set; }
        public override string ToString()
        {
            string result = "Meal:\n";
            result += $"name: {Name}\n";
            result += $"price: {Price}\n";
            result += $"portionSize: {PortionSize}\n";
            result += $"type: {Type}";
            return result;
        }
    }
}
