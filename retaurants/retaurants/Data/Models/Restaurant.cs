using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Data.Models
{
    public class Restaurant
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "restaurant name is too long!")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "location name is too long!")]
        public string Location { get; set; }
        [Required]
        [DefaultValue(20)]
        public int Capacity { get; set; }
        /// <summary>
        /// Foreign Key connected with table Drivers
        /// </summary>
        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public Menu Menu { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "restaurant link is too long")]
        public string Link { get; set; }
        public override string ToString()
        {
            string result = "Restaurant:\n";
            result += $"name: {Name}\n";
            result += $"location: {Location}\n";
            result += $"{MenuId.ToString()}\n";
            result += $"capacity: {Capacity}\n";
            result += $"link: {Link}";
            return result;
        }
    }
}
