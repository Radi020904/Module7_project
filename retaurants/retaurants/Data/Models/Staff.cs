using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Data.Models
{
    public class Staff
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "first name is too long!")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "last name is too long!")]
        public string LastName { get; set; }
        [Required]
        [Range(typeof(int), "18", "90")]
        public double Age { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "staff job is too long")]
        public string Job { get; set; }
        [Required]
        [Range(typeof(double), "100", "1000")]
        public double Salary { get; set; }

        public override string ToString()
        {
            string result = "Staff:\n";
            result += $"fist name: {FirstName}\n";
            result += $"last name: {LastName}\n";
            result += $"age: {Age}\n";
            result += $"Job: {Job}\n";
            result += $"Salary: {Salary}";
            return result;
        }
    }
}
